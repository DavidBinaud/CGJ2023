using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopSection : MonoBehaviour, IInteraction
{
    [SerializeField] private ShopItem shopItem;
    [SerializeField] CanvasGroup shopMessageAlpha;
    [SerializeField] TextMeshProUGUI shopMessage;

    [SerializeField] Transform displayAnchor;

    Coroutine currentCoroutine;

    void Start(){
        GameObject item = Instantiate(shopItem.shopDisplay);
        item.transform.parent = displayAnchor;
        item.transform.localPosition = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DisplayShopData();
            PlayerController.Instance.currentInteraction = this;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            HideShopData();
            if((Object)PlayerController.Instance.currentInteraction == this){
                PlayerController.Instance.currentInteraction = null;
            }
        }
    }

    public void Use()
    {
        Debug.Log("Used " + shopItem.name);
        GameObject prefab = Instantiate(shopItem.prefab);
        IShopItem prefabISI = prefab.GetComponent<IShopItem>();
        if (PlayerController.Instance.playerData.upgradeLevels[(int)shopItem.id] > 0)
        {
            prefabISI.Upgrade();
        }
        else
        {
            prefabISI.Unlock();
        }
        DisplayShopData();
        Destroy(prefab);
    }

    private void DisplayShopData(){
        if(PlayerController.Instance.playerData.upgradeLevels[(int)shopItem.id] == shopItem.upgradeValue.Count){
            shopMessage.text = "MAX";
        }
        else{
            string progression = PlayerController.Instance.playerData.upgradeLevels[(int)shopItem.id].ToString() + "/" + shopItem.upgradeValue.Count.ToString();
            if (PlayerController.Instance.playerData.upgradeLevels[(int)shopItem.id] > 0)
            {
                shopMessage.text = shopItem.upgradeText + "\n" + progression;
            }
            else
            {
                shopMessage.text = shopItem.unlockText + "\n" + progression;
            }
        }
        
        if (currentCoroutine is not null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(TransitionAlphaTo(1f));
    }

    private void HideShopData()
    {
        if (currentCoroutine is not null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(TransitionAlphaTo(0f));
    }
    

    IEnumerator TransitionAlphaTo(float value){
        while(shopMessageAlpha.alpha != value){
            shopMessageAlpha.alpha += Mathf.Sign(value - shopMessageAlpha.alpha) * Time.deltaTime;
            if(Mathf.Abs(value - shopMessageAlpha.alpha) < 0.05f){
                shopMessageAlpha.alpha = value;
            }
            yield return null;
        }
        yield return null;
    }

}
