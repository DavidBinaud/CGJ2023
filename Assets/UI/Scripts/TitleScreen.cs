using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public static TitleScreen Instance;

    void Awake(){
        if(Instance == null){
            Instance = this;
        }
    }

    void Start(){
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        SceneManager.LoadScene("PersistentData", LoadSceneMode.Additive);
    }

    public void PlaySelectedSave()
    {
        SceneManager.UnloadSceneAsync("SaveSelection");
        AsyncOperation ao = SceneManager.UnloadSceneAsync(0);
        ao.completed += LoadGame;

    }
    private void LoadGame(AsyncOperation ao){
        SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
    }
}
