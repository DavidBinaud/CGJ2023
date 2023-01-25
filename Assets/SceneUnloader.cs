using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUnloader : MonoBehaviour
{
    [SerializeField] private string sceneToUnload;
    void Start(){
        SceneManager.UnloadSceneAsync("TitleScreen");
    }
}
