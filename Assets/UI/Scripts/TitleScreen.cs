using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    void Start(){
        audioSource.Play();

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        
    }
}
