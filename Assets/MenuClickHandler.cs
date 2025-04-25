using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClickHandler : MonoBehaviour
{
    public void OnExitClick()
    {
        Debug.Log("Button Clicked!");
        UnityEditor.EditorApplication.isPlaying = false;  // Stop Play Mode in Editor
        Application.Quit();  // Quit in a built application
    }
}
