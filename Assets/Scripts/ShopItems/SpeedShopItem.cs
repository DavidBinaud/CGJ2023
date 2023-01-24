using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedShopItem : MonoBehaviour, IShopItem
{
    public ShopItem data;
    public void Unlock() {
        int value = (int)data.upgradeValue[PlayerController.Instance.playerData.upgradeLevels[(int)data.id]];
        int cost = (int)data.upgradeCost[PlayerController.Instance.playerData.upgradeLevels[(int)data.id]];
        PlayerController.Instance.UpgradeSpeed(value, cost);
    }

    public void Upgrade(){
        if(PlayerController.Instance.playerData.upgradeLevels[(int)data.id] >= data.upgradeValue.Count){
            return;
        }
        int value = (int)data.upgradeValue[PlayerController.Instance.playerData.upgradeLevels[(int)data.id]];
        int cost = (int)data.upgradeCost[PlayerController.Instance.playerData.upgradeLevels[(int)data.id]];
        PlayerController.Instance.UpgradeSpeed(value, cost);
    }
}
