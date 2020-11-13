using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    [SerializeField] List<DropItem> dropItems = new List<DropItem>();

    private List<Item> items = new List<Item>();

    public List<Item> GetLoots()
    {
        RollLoot();
        return items;
    }

    private void RollLoot()
    {
        foreach (DropItem dropItem in dropItems)
        {
            int roll = Random.Range(0, 100);

            if (roll <= dropItem.rate)
            {
                items.Add(new Item { itemType = dropItem.itemType, amount = dropItem.amount });
            }
        }
    }

    [System.Serializable]
    public class DropItem
    {
        public Item.ItemType itemType;
        public int amount;
        public float rate;
    }
}
