using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezeSpell : MonoBehaviour, ISpell
{
    
    public void Cast()
    {
        Vector3 playerPosition = PlayerController.Instance.transform.position;
        List<GameObject> enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        List<GameObject> enemiesInRange =
            enemies.FindAll((e) => Vector3.Distance(e.transform.position, playerPosition) < 50);
        
        /*
         Freeze the enemies
         * foreach (var enemy in enemiesInRange)
        {
            enemy.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
        */
        Debug.Log("TimeFreeze !");
    }

    public void unFreeze()
    {
        
    }
}
