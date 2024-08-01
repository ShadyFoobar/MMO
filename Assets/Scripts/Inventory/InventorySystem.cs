using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public GameObject canvasToToggle; // Assign the Canvas in the Inspector
    public GameObject itemSlotPrefab; // Prefab for the item slot
    public Transform itemSlotParent; // Parent object to hold item slots

    private List<ItemDetails> inventory = new List<ItemDetails>(); // List to store inventory items

    void Start()
    {
        // Initialize with some items (example)
        //AddItem(new Item { itemName = "Sword", itemIcon = /*YourIconHere*/ });
        //AddItem(new Item { itemName = "Shield", itemIcon = "test" /*YourIconHere*/ });
        UpdateInventoryUI();
    }

    public void AddItem(ItemDetails details )
    {
        inventory.Add(details);
        UpdateInventoryUI();
    }

    private IEnumerator FreezeItem(GameObject item)
    {
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(3);
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    public void RemoveItem(ItemDetails itemToRemove)
    {
        foreach(ItemDetails i in inventory)
        {
            if(i.itemName == itemToRemove.itemName)
            {
                i.item.transform.position = Camera.main.transform.forward + Camera.main.transform.position;
                i.item.SetActive(true);
                inventory.Remove(i);
                StartCoroutine(FreezeItem(i.item));
                break;
            }
        }
        UpdateInventoryUI();
    }

    void UpdateInventoryUI()
    {
        // Clear existing slots
        foreach (Transform child in itemSlotParent)
        {
            Destroy(child.gameObject);
        }

        // Create new slots
        foreach (var item in inventory)
        {
            GameObject itemSlot = Instantiate(itemSlotPrefab, itemSlotParent);
            itemSlot.GetComponentInChildren<TMP_Text>().text = item.itemName;
            itemSlot.GetComponentInChildren<Image>().sprite = item.itemIcon;
            itemSlot.GetComponent<ItemDetails>().setItemDetails(item);
        }
    }

    public void OpenInventory()
    {
        if (canvasToToggle != null)
        {
            Debug.Log("opening canvas");
            bool isActive = canvasToToggle.activeSelf;
            canvasToToggle.SetActive(!isActive);
        }
    }
}


