using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItem", menuName = "ScriptableObjects/ShopItem")]
public class ShopItem : ScriptableObject
{
    public Helpers.ShopItems id;
    public string unlockText;
    public string upgradeText;

    public GameObject prefab;

    public GameObject shopDisplay;

    public List<float> upgradeValue;
    public List<int> upgradeCost;

}
