using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource calm;
    [SerializeField] private AudioSource fight;

    public static MusicManager Instance;
    void Awake(){
        if(Instance == null){
            Instance = this;
        }
    }
    void Start(){
        calm.Play();
    }

    public void Switch(){
        if(calm.isPlaying){
            fight.Play();
            calm.Stop();
        }
        else{
            calm.Play();
            fight.Stop();
        }
    }


}
