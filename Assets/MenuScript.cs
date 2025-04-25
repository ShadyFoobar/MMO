using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject canvasToToggle; // Assign the Canvas in the Inspector

    void Start()
    {
    }


    public void OpenMenu()
    {
        if (canvasToToggle != null)
        {
            Debug.Log("opening canvas");
            bool isActive = canvasToToggle.activeSelf;
            canvasToToggle.SetActive(!isActive);
        }
    }
}


