
using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class ItemDetails : MonoBehaviour
{
    [SerializeField] public GameObject item;


    [SerializeField] public Sprite itemIcon;
    [SerializeField] public string itemName;
    [SerializeField] public string prefabName;
    [SerializeField] public string prefabPath;
    [SerializeField] public string itemType;

    [SerializeField] private InputActionReference leftSelect;
    [SerializeField] private InputActionReference rightSelect;
    [SerializeField] private InputActionReference leftActivate;
    [SerializeField] private InputActionReference rightActivate;


    void Start()
    {
        item = gameObject;

    }

    private void OnTriggerStay(Collider collider)
    {
        // Check Grip Released

        if (collider.gameObject.tag == "InventoryObject" 
            && (leftSelect.action.IsPressed() || rightSelect.action.IsPressed())
            && (leftActivate.action.IsPressed() || rightActivate.action.IsPressed()))
        {
            Debug.Log("Found Inventory object");
            bool hasAdded = collider.gameObject.GetComponent<CastorInventorySystem>().AddItem(this);
            Debug.Log(hasAdded + " added");
            if (hasAdded)
            {
                item.SetActive(false);
            }
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
