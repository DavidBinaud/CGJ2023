using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellDisplay : MonoBehaviour
{
    [SerializeField] private Image[] spells;
    private int selectedSpell = -1;

    

    
    void Start()
    {
        PlayerController.Instance.onSelectCard += SetSelectedSpell;
        PlayerController.Instance.onChangeHand += SetSpellHand;
        SetSpellHand();
    }

    private void SetSpellHand()
    {
        Spell[] hand = PlayerController.Instance.hand;
        for (int i = 0; i < spells.Length; i++)
        {
            if(i >= hand.Length){
                return;
            }
            if (hand[i] is null)
            {
                spells[i].sprite = null;
                spells[i].color = new Color(0.2f, 0.2f, 0.2f, 0.2f);
            }
            else
            {
                spells[i].color = Color.white;
                spells[i].sprite = hand[i].card;
            }
        }
    }

    private void SetSelectedSpell(int i){
        if(selectedSpell >= 0 && selectedSpell < 4){
            spells[selectedSpell].transform.localScale = Vector3.one;
            //spells[selectedSpell].transform.position = spells[selectedSpell].transform.position - 30f * spells[selectedSpell].transform.up;
        }
        selectedSpell = i;
        spells[selectedSpell].transform.localScale = Vector3.one * 1.4f;
        spells[selectedSpell].transform.SetAsLastSibling();
        //spells[selectedSpell].transform.position = spells[selectedSpell].transform.position + 30f * spells[selectedSpell].transform.up;
    }
}
