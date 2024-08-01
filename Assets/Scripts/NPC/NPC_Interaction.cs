using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interaction : MonoBehaviour
{

    public GameObject canvasToToggle; // Assign the Canvas in the Inspector

    public void ToggleCanvas()
    {
        if (canvasToToggle != null)
        {
            Debug.Log("opening canvas");
            bool isActive = canvasToToggle.activeSelf;
            canvasToToggle.SetActive(!isActive);
        }
    }
}
