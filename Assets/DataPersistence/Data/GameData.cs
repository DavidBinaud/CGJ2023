using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    /*
    * Edit to your liking.
    * Everything must be serializable. Define and use classes for complex objects.
    */
    public int maxSand;
    public int shards;
    public float moveSpeed;

    public List<int> upgradeLevels;



    public GameData(){
        this.maxSand = 2;
        this.shards = 0;
        this.moveSpeed = 5f;
        upgradeLevels = new List<int>();
        for (int i = 0; i < 11; i++)
        {
            upgradeLevels.Add(0);
        }

    }
    public void ClearLists() {
        /*
        * Add the lists here so they can be emptied.
        * exampleListName.Clear();
        */
    }
}
