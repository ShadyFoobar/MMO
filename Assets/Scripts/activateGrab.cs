using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateGrab : MonoBehaviour
{
    bool isActivated = false;
    private Collider attachedItem = null;

    public void activate()
    {
        isActivated = true;
    }

    public void deactivate()
    {
        isActivated = false;
        attachedItem.gameObject.transform.SetParent(null);
        attachedItem.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        attachedItem = null;
    }

    private void OnTriggerStay(Collider collider)
    {
        if (isActivated && collider.gameObject.tag == "Item" && attachedItem == null)
        {
            attachedItem = collider;
            collider.gameObject.transform.SetParent(gameObject.transform);
            collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }

    }

}
 