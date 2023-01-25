using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TimeFreezeSpell : MonoBehaviour, ISpell
{
    [SerializeField] private GameObject spell;
    public void Cast()
    {
        Instantiate(spell, transform.position, Quaternion.identity);
    }
}
