using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShardsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI shards;


    void Start()
    {
        PlayerController.Instance.onShardAmountChange += SetAmount;
    }


    public void SetAmount(int i)
    {
        shards.text = i.ToString();
    }
}
