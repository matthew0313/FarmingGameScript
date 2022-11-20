using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager instance{
        get{
            if(_instance==null){
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    public int Money;
    public int Level;
    int _Experience;
    public int Experience{
        get{
            return _Experience;
        }
        set{
            _Experience = value;
            if(_Experience>=ExpRequired){
                _Experience -= ExpRequired;
                LevelUp();
            }
        }
    }
    public int ExpRequired;

    void LevelUp(){

    }
}
