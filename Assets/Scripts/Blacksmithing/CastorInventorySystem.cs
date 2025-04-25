using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CastorInventorySystem : MonoBehaviour
{
    public GameObject canvasToToggle; // Assign the Canvas in the Inspector
    public GameObject itemSlotPrefab; // Prefab for the item slot
    public Transform itemSlotParent; // Parent object to hold item slots

    public GameObject scrollSlotPrefab; // Parent object to hold item slots



    public int maxNumberOfItems = 1;

    private List<ItemDetails> inventory = new List<ItemDetails>(); // List to store inventory items
    public ItemDetails schema; // schema for creation


    void Start()
    {
        // Initialize with some items (example)
        //AddItem(new Item { itemName = "Sword", itemIcon = /*YourIconHere*/ });
        //AddItem(new Item { itemName = "Shield", itemIcon = "test" /*YourIconHere*/ });
        UpdateInventoryUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            canvasToToggle.SetActive(!canvasToToggle.activeSelf);
            //Debug.Log("Toggled: " + canvasToToggle.activeSelf);
        }
    }

    public bool AddItem(ItemDetails details)
    {

        if(details.itemType == "Scroll")
        {
            schema = details;
            UpdateScrollSlot();
            return true;

        } 
        else if (inventory.Count < maxNumberOfItems)
        {
            inventory.Add(details);
            UpdateInventoryUI();
            return true;
        }
        return false;

    }

    private IEnumerator FreezeItem(GameObject item)
    {
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(3);
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    public void RemoveItem(ItemDetails itemToRemove)
    {
        foreach (ItemDetails i in inventory)
        {
            if (i.itemName == itemToRemove.itemName)
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

    void UpdateScrollSlot()
    {

        scrollSlotPrefab.GetComponent<Image>().sprite = schema.itemIcon;


    }

    public void OpenInventory()
    {
        if (canvasToToggle != null)
        {
            Debug.Log("Toggled: " + canvasToToggle.activeSelf);
            canvasToToggle.SetActive(!canvasToToggle.activeSelf);
        }
    }

}


