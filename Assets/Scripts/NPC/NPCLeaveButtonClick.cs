using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLeaveButtonClick : MonoBehaviour
{

    public GameObject NPC_Dialog;


    public void CallToggleDialog()
    {
        NPC_Dialog.GetComponent<NPC_Interaction>().ToggleCanvas();

    }
}
