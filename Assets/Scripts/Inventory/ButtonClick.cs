using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Button button;


    public void OnClick()
    {
        ItemDetails details = GetComponentInParent<ItemDetails>();
        GetComponentInParent<InventorySystem>().RemoveItem(details);

        button.GetComponent<Image>().color = Color.red;

    }
}
