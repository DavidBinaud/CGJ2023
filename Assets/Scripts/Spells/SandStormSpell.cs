using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandStormSpell : MonoBehaviour, ISpell
{

    public GameObject prefab;

    
    public void Cast()
    {
        GameObject tornado = Instantiate(prefab);
        tornado.transform.position = PlayerController.Instance.transform.position;
        Debug.Log("SandStorm Creation!");
    }

}
