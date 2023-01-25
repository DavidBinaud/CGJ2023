using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSelection : MonoBehaviour
{
    public void SetSaveFile(string savefile){
        FindObjectOfType<SaveFileData>().SetSaveFileName(savefile);
        TitleScreen.Instance.PlaySelectedSave();
    }
}
