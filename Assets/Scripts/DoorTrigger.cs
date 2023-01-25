using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DoorTrigger : MonoBehaviour, IInteraction
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneToUnload;
    [SerializeField] private string text;
    [SerializeField] CanvasGroup doorMessageAlpha;
    [SerializeField] TextMeshProUGUI doorMessage;

    Coroutine currentCoroutine;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DisplayDoorMessage();
            PlayerController.Instance.currentInteraction = this;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            HideDoorMessage();
            if ((Object)PlayerController.Instance.currentInteraction == this)
            {
                PlayerController.Instance.currentInteraction = null;
            }
        }
    }

    public void Use()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneToLoad);
        ao.completed += UnloadShop;
    }

    private void UnloadShop(AsyncOperation ao){
        SceneManager.UnloadSceneAsync(sceneToUnload);
    }

    private void DisplayDoorMessage()
    {
        doorMessage.text = text;

        if (currentCoroutine is not null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(TransitionAlphaTo(1f));
    }

    private void HideDoorMessage()
    {
        if (currentCoroutine is not null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(TransitionAlphaTo(0f));
    }


    IEnumerator TransitionAlphaTo(float value)
    {
        while (doorMessageAlpha.alpha != value)
        {
            doorMessageAlpha.alpha += Mathf.Sign(value - doorMessageAlpha.alpha) * Time.deltaTime;
            if (Mathf.Abs(value - doorMessageAlpha.alpha) < 0.05f)
            {
                doorMessageAlpha.alpha = value;
            }
            yield return null;
        }
        yield return null;
    }
}
