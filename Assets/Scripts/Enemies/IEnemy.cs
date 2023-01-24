using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IEnemy {

    public void Init();
    public void Attack();

    public void Move();
    
}
