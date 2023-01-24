using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartSelection : MonoBehaviour
{
    [SerializeField] private GameObject firstSelected;

    void Start(){
        FindObjectOfType<EventSystem>().SetSelectedGameObject(firstSelected);
    }
}
