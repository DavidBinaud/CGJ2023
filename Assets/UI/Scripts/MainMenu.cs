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
    }

    public void Play()
    {
        SceneManager.LoadScene("SaveSelection", LoadSceneMode.Additive);
    }
}
