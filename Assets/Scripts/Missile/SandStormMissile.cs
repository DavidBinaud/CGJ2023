using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandStormMissile : MonoBehaviour
{
    [SerializeField] 
    private float timeDuration = 0;
    
    [SerializeField] private float attractionForce = 2f;

    [SerializeField] private float attractionDistance = 25f;
    // Start is called before the first frame update
    void Start()
    {
        timeDuration = 2.5f;
    }

    // Update is called once per frame

    private void Update()
    {
        if (timeDuration > 0)
        {
            Debug.Log("SandStorm Running!");
            Vector3 playerPosition = PlayerController.Instance.transform.position;
            List<GameObject> enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
            List<GameObject> enemiesInRange =
                enemies.FindAll((e) => Vector3.Distance(e.transform.position, playerPosition) < attractionDistance);

            foreach (var enemy in enemiesInRange)
            {
                //Appliquer une force d'attraction
                enemy.transform.position += (transform.position - enemy.transform.position).normalized *
                                            (Time.deltaTime *
                                             attractionForce);

                //Appliquer des dégâts
            }

            timeDuration -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
