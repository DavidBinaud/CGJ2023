using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private AudioSource playerSounds;

    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioClip dash;
    [SerializeField] private AudioClip attack;
    [SerializeField] private AudioClip draw;
    [SerializeField] private AudioClip sacrifice;
    [SerializeField] private AudioClip cast;
    [SerializeField] private AudioClip death;


    void Start()
    {
        playerSounds = GetComponent<AudioSource>();
    }

    public void PlayHit(){
        playerSounds.PlayOneShot(hit);
    }
    public void PlayDash()
    {
        playerSounds.PlayOneShot(dash);
    }
    public void PlayAttack()
    {
        playerSounds.PlayOneShot(attack);
    }
    public void PlayDraw()
    {
        playerSounds.PlayOneShot(draw);
    }
    public void PlaySacrifice()
    {
        playerSounds.PlayOneShot(sacrifice);
    }
    public void PlayCast()
    {
        playerSounds.PlayOneShot(cast);
    }
}
