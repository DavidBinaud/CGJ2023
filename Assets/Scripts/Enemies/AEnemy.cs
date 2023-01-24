using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class AEnemy : MonoBehaviour {
    public abstract void Attack();

    public abstract void Moove();

    public abstract void SetStartPosition(Vector3 position);
    
}
