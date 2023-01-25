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
    }

    void UpdateShieldVisual()
    {
        int sandAmount = PlayerController.Instance.playerData.sandAmount;
        clearShields();
        Transform currentPosition = transform;
        int angleBetweenTwoShields = 360 / sandAmount;
        for (int i = 0; i < sandAmount; i++)
        {
            //Transform c = Transform.Instantiate(currentPosition);
            GameObject Object = Instantiate(prefab, transform);
            Object.transform.RotateAround(PlayerController.Instance.transform.position, new Vector3(0,1,0), i * angleBetweenTwoShields);
        }
    }

    void clearShields()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            Debug.Log(child.name);
            Destroy(child);
        }
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0,1,0), 90 * Time.deltaTime);
    }
}
