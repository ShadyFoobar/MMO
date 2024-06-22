using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateGrab : MonoBehaviour
{
    bool isActivated = false;

    public void activate()
    {
        isActivated = true;
    }

    public void deactivate()
    {
        isActivated = false;
        gameObject.transform.SetParent(null);
     }

    private void OnTriggerEnter(Collider collision)
    {
        if (isActivated && collision.gameObject.tag == "Item")
        {
            collision.gameObject.transform.SetParent(gameObject.transform);
        }


    }

}
 