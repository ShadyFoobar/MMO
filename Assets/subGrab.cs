
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class subGrab : MonoBehaviour
{
    private XRBaseInteractable interactable;

    private void Awake()
    {
        interactable = GetComponentInParent<XRBaseInteractable>();
    }

    private void OnEnable()
    {
        interactable.activated.AddListener(GrabObject);
    }

    private void GrabObject(ActivateEventArgs args)
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Debug.Log("Can Grab Item");
        } 
    }
}
