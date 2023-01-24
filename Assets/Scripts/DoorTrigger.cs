using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private string nextScene;
    [SerializeField] private string currentScene;

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(currentScene);
        }
    }
}
