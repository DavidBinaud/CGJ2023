using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScroller : MonoBehaviour
{
    
    void Update()
    {
        transform.position = transform.position + Vector3.up * 100f * Time.deltaTime;
    }

    public void ExitCredits(){
        SceneManager.UnloadSceneAsync("Credits");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }
}
