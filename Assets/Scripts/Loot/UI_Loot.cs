using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Loot : MonoBehaviour
{
    [SerializeField] private LootButton lootButtonPrefab;
    [SerializeField] private Transform lootsContainer;

    float MAX_LOOTS = 4;

    private void Start()
    {
        AddLoot(new Item { itemType = Item.ItemType.Arrow, amount = 1 });
        AddLoot(new Item { itemType = Item.ItemType.Coin, amount = 10 });
    }

    private void Update()
    {
        RefreshLoots();
    }

    private void AddLoot(Item item)
    {
        LootButton lootButton = Instantiate(lootButtonPrefab, lootsContainer);
        lootButton.MyLoot = item;

        lootButton.MyIcon.sprite = item.GetSprite();
        lootButton.MyTitle.text = item.itemType.ToString() + " x" + item.amount.ToString();
    }

    public void RefreshLoots()
    {
        if (lootsContainer.childCount <= 0)
        {
            CloseWindow();
        }
    }

    public void CloseWindow()
    {
        Destroy(gameObject);
    }
}
