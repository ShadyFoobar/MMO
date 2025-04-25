using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Info : MonoBehaviour
{
    public string Name;
    public string MainTextDescription;
    public string NPC_Id;
    public Type type;
    public Canvas infoCanvas;
    public Canvas mainCanvas;
    public Canvas storeCanvas;

    public enum Type
    {
        Normal,
        Merchant,
        Blacksmith,
    }
    private void Start()
    {
        // function of getting all npc information based on the NPC_ID
        setNPCInformation();
    }

    public void setNPCInformation()
    {
        infoCanvas.GetComponentInChildren<TMP_Text>().text = Name;

    }
}
