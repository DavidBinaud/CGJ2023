using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandStormSpell : MonoBehaviour, ISpell
{
    public void Cast()
    {
        Debug.Log("SandStorm !");
    }
}
