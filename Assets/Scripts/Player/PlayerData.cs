using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour, IDataPersistence
{
    
    public List<int> upgradeLevels;
    

    public int sandAmount = 2;
    public int maxSandAmount = 3;
    public float speed = 5f;
    public float dashForce = 5f;

    public float attackSpeed = 180f;
    public float attackDelay = 0.5f;
    public int shards;


    public void SaveData(GameData gameData){
        gameData.maxSand = maxSandAmount;
        gameData.moveSpeed = speed;
        gameData.shards = shards;
        gameData.upgradeLevels = upgradeLevels;
    }
    public void LoadData(GameData gameData){
        shards = gameData.shards;
        maxSandAmount = gameData.maxSand;
        speed = gameData.moveSpeed;
        upgradeLevels = gameData.upgradeLevels;
    }
}
