using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_System : MonoBehaviour
{
    bool player_detection = false;
    public GameObject canvas;
    // Update is called once per frame
    void Update()
    {
        if(player_detection)
        {
            print("Dialog Starting");
            canvas.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerBody")
        {
            player_detection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player_detection = false;
        canvas.SetActive(false);
    }
}
