using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezeSpell : MonoBehaviour, ISpell
{
    public void Cast()
    {
        Debug.Log("TimeFreeze !");
    }
}
