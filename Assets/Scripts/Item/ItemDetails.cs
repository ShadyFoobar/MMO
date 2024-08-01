using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class ItemDetails : MonoBehaviour
{
    [SerializeField] public GameObject item;

    [SerializeField] public Sprite itemIcon;
    [SerializeField] public string itemName;
    [SerializeField] public string prefabName;
    [SerializeField] public string prefabPath;
    [SerializeField] private InputActionReference grip;


    void Start()
    {
        item = gameObject;
    }

    private void Update()
    {

    }
    private void OnTriggerStay(Collider collider)
    {
        Debug.Log("Is grip pressed");
        Debug.Log(grip.action.IsPressed());
        // Check Grip Released
        if(collider.gameObject.tag == "InventoryObject" && !grip.action.IsPressed())
        {
            Debug.Log("Found Inventory object");
            collider.gameObject.GetComponent<InventorySystem>().AddItem(this);            
            item.SetActive(false);
            Debug.Log("Destroy item");
        }
    }

    public void setItemDetails(ItemDetails details)
    {
        itemIcon = details.itemIcon;
        itemName = details.itemName;
        prefabName = details.prefabName;
        prefabPath = details.prefabPath;
        item = details.item;
    }

}
