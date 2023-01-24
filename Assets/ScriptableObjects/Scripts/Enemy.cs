using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
public class Enemy : ScriptableObject
{
    public int Health;
    public int Damage;
    public float moveSpeed;
    public float attackDelay;
    public float attackSpeed;

    public float rangeAttack;
    public float rangeAgro;
}
