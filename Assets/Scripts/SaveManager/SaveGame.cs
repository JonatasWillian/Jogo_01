using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
   public void SaveGameButton()
    {
        SaveManager.Instance.SaveCurrentLife(Player.Instance.healthBase.CurrentLife);
        SaveManager.Instance.SaveItens();
        SaveManager.Instance.CommitSave();
    }
}
