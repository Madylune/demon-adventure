using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotButton : MonoBehaviour, IPointerClickHandler
{
    private Item item;

    public void GetItem(Item item)
    {
        this.item = item;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            PlayerScript.MyInstance.MyInventory.UseItem(item);
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            PlayerScript.MyInstance.MyInventory.RemoveItem(item);
        }
    }
}
