using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private Transform itemsContainer;
    [SerializeField] private GameObject itemSlot;

    float MAX_ITEMS_IN_INVENTORY = 5;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnListChanged(object sender, EventArgs e)
    {
        RefreshInventoryItems();
    }

    public void RefreshInventoryItems()
    {
        if (itemsContainer.childCount < MAX_ITEMS_IN_INVENTORY)
        {
            foreach (Transform child in itemsContainer)
            {
                if (child == itemSlot) continue;
                Destroy(child.gameObject);
            }
            foreach (Item item in inventory.GetItemList())
            {
                GameObject slot = Instantiate(itemSlot, itemsContainer).gameObject;
                Image icon = slot.transform.Find("Icon").GetComponent<Image>();
                icon.sprite = item.GetSprite();
                Text count = slot.transform.Find("Count").GetComponent<Text>();
                count.text = item.amount.ToString();
            }
        }
    }
}
