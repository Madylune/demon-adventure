using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Loot : MonoBehaviour
{
    [SerializeField] private LootButton lootButtonPrefab;
    [SerializeField] private Transform lootsContainer;

    private void Start()
    {
        AddLoot(new Item { itemType = Item.ItemType.Arrow, amount = 1 });
        AddLoot(new Item { itemType = Item.ItemType.Coin, amount = 10 });
    }

    private void AddLoot(Item item)
    {
        LootButton lootButton = Instantiate(lootButtonPrefab, lootsContainer);

        lootButton.MyIcon.sprite = item.GetSprite();
        lootButton.MyTitle.text = item.itemType.ToString() + " x" + item.amount.ToString();
    }

    public void CloseWindow()
    {
        Destroy(gameObject);
    }
}
