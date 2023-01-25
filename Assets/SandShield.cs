using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class SandShield : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    // Update is called once per frame

    private void Start()
    {
        UpdateShieldVisual();
        PlayerController.Instance.onSandAmountChange += UpdateShieldVisual;
    }

    void UpdateShieldVisual()
    {
        int sandAmount = PlayerController.Instance.playerData.sandAmount;
        ClearShields();
        if(sandAmount < 1){
            return;
        }

        int angleBetweenTwoShields = 360 / sandAmount;
        for (int i = 0; i < sandAmount; i++)
        {

            GameObject shield = Instantiate(prefab, transform);
            shield.transform.RotateAround(PlayerController.Instance.transform.position, new Vector3(0,1,0), i * angleBetweenTwoShields);
        }
    }
    void UpdateShieldVisual(int amount)
    {
        int sandAmount = amount;
        ClearShields();
        if (sandAmount < 1)
        {
            return;
        }

        int angleBetweenTwoShields = 360 / sandAmount;
        for (int i = 0; i < sandAmount; i++)
        {

            GameObject shield = Instantiate(prefab, transform);
            shield.transform.RotateAround(PlayerController.Instance.transform.position, new Vector3(0, 1, 0), i * angleBetweenTwoShields);
        }
    }

    void ClearShields()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }

    }

    private void Update()
    {
        transform.Rotate(new Vector3(0,1,0), 90 * Time.deltaTime);
    }
}
