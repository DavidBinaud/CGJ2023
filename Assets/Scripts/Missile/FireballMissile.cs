using System;
using Missile;
using Unity.VisualScripting;
using UnityEngine;

public class fireballMissile : MonoBehaviour
{
    public float lifetime = 2.5f;

    private Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Fireball trigger");
        if (other.tag == "Enemy")
        {
            Debug.Log("Fireball hit");
            IDamageable damageableScript = other.gameObject.GetComponent<IDamageable>();
            //Application des dégâts
            //damageableScript.TakeDamage(1);
            
            //Animation explosion ou mise feu autour 
            setAnimatorDestroy(1);
        }
    }

    private void Update()
    {
        if (lifetime <= 0)
        {
            //Animation Eteint
            setAnimatorDestroy(0);
        }
        else
        {
            lifetime -= Time.deltaTime;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Exit"))
        {
            Destroy(gameObject);
        }
    }

    private void setAnimatorDestroy(int animatorDestroyIndex)
    {
        animator.SetTrigger("Destroy");
        animator.SetFloat("DestroyAnimIndex", animatorDestroyIndex);
    }
}