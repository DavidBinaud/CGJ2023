using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SandDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sand;


    void Start()
    {
        PlayerController.Instance.onSandAmountChange += SetAmount;
    }


    public void SetAmount(int i)
    {
        sand.text = i.ToString();
    }
}
