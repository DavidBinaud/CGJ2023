using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TimeFreezeObject : MonoBehaviour
{
    void Start()
    {
        Vector3 playerPosition = PlayerController.Instance.transform.position;
        List<GameObject> enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        List<GameObject> enemiesInRange =
            enemies.FindAll((e) => Vector3.Distance(e.transform.position, playerPosition) < 50);


        //Freeze the enemies
        foreach (var enemy in enemiesInRange)
        {
            enemy.GetComponent<NavMeshAgent>().speed = 0;
            enemy.GetComponent<Animator>().speed = 0f;

            //.constraints = RigidbodyConstraints.FreezePosition;
        }

        StartCoroutine(Unfreeze(enemiesInRange));
    }

    IEnumerator Unfreeze(List<GameObject> enemies)
    {
        yield return new WaitForSeconds(3f);
        foreach (var enemy in enemies)
        {
            enemy.transform.GetComponent<BasicMob>().Unfreeze();

            //.constraints = RigidbodyConstraints.FreezePosition;
        }
        Destroy(gameObject);
    }
}
