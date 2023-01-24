using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpell : MonoBehaviour, ISpell
{
    public void Cast(){
        Debug.Log("Shield !");
    }
}
