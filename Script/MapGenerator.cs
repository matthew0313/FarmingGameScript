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
    public void Generate(){
        TestButton.SetActive(false);
        for(int i = 0 ; i < mapX ; i++){
            for(int k = 0 ; k < mapY ; k++){
                if(occupied[i,k]==false){
                    for(int o = 0 ; o < SpawnChunks.Length ; o++){
                        if(Random.Range(0.0f, 100.0f)<=SpawnChunks[o].Chance){
                            ChunkSpawn(o, i, k, Mathf.RoundToInt(Random.Range((float)SpawnChunks[o].NodeSizeMax, (float)SpawnChunks[o].NodeSizeMin)), 0);
                        }
                    }
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
    public float Chance;
    public int NodeSizeMax, NodeSizeMin;
}
