using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{

    public void QuitGame(){
        Debug.Log("App quit in build");
        Application.Quit();
    }

    public void Credits(){
        SceneManager.LoadScene("Credits", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("MainMenu");
    }

    public void Play()
    {
        SceneManager.LoadScene("SaveSelection", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("MainMenu");
    }
}
