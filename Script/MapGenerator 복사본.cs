using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class MapGenerator : MonoBehaviour
{
    [SerializeField] GameObject TestButton;
    [SerializeField] SC[] SpawnChunks;
    [SerializeField] const int mapX = 100, mapY = 100;
    [SerializeField] Transform mapObject;
    [SerializeField] LandScript[,] map = new LandScript[mapX*4,mapY*4];
    bool[,] occupied = new bool[mapX,mapY];
    public async void Generate(){
        TestButton.SetActive(false);
        for(int i = 0 ; i < SpawnChunks.Length ; i++){
            int e = Random.Range(SpawnChunks[i].MinAmount, SpawnChunks[i].MaxAmount);
            for(int k = 0 ; k < e ; k++){
                int a = Random.Range(0, mapX), b = Random.Range(0, mapY);
                if(occupied[a, b]==false){
                    ChunkSpawn(i, a, b, Random.Range(SpawnChunks[i].NodeSizeMin, SpawnChunks[i].NodeSizeMax), 0);
                }
                else{
                    k--;
                    continue;
                }
            }
        }
        for(int i = 0 ; i < mapX ; i++){
            for(int k = 0 ; k < mapY ; k++){
                if(occupied[i,k]==false){
                    occupied[i,k] = true;
                    GameObject a = Instantiate(SpawnChunks[0].Chunk, mapObject);
                    a.transform.position = new Vector3(2.0f*(float)i, 0.0f, 2.0f*(float)k);
                    map[i*2+1,k*2] = a.transform.GetChild(0).GetComponent<LandScript>();
                    map[i*2,k*2] = a.transform.GetChild(1).GetComponent<LandScript>();
                    map[i*2+1,k*2+1] = a.transform.GetChild(2).GetComponent<LandScript>();
                    map[i*2,k*2+1] = a.transform.GetChild(3).GetComponent<LandScript>();
                }
            }
        }
    }
    void ChunkSpawn(int which, int X, int Y, int size, int current){
        if(occupied[X,Y]==true) return;
        occupied[X,Y] = true;
        GameObject a = Instantiate(SpawnChunks[which].Chunk, mapObject);
        a.transform.position = new Vector3(2.0f*(float)X, 0.0f, 2.0f*(float)Y);
        map[X*2+1,Y*2] = a.transform.GetChild(0).GetComponent<LandScript>();
        map[X*2,Y*2] = a.transform.GetChild(1).GetComponent<LandScript>();
        map[X*2+1,Y*2+1] = a.transform.GetChild(2).GetComponent<LandScript>();
        map[X*2,Y*2+1] = a.transform.GetChild(3).GetComponent<LandScript>();
        if(current==size-1) return;
        if(X+1<mapX) ChunkSpawn(which, X+1, Y, size, current+1);
        if(X-1>0) ChunkSpawn(which, X-1, Y, size, current+1);
        if(Y+1<mapY) ChunkSpawn(which, X, Y+1, size, current+1);
        if(Y-1>0) ChunkSpawn(which, X, Y-1, size, current+1);
    }
}
[System.Serializable] struct SC{
    public GameObject Chunk;
    public int MaxAmount, MinAmount;
    public int NodeSizeMax, NodeSizeMin;
}
