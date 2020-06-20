using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSaveData : MonoBehaviour
{
    public void deleteSave()
    {
        SaveSystem.DeleteData();
    }
}
