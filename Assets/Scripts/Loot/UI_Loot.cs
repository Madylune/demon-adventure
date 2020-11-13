using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Loot : MonoBehaviour
{
    [SerializeField] private LootButton lootButtonPrefab;
    [SerializeField] private Transform lootsContainer;

    public List<Item> MyLoots { get; set; }

    private void Start()
    {
        foreach (Item item in MyLoots)
        {
            AddLoot(new Item { itemType = item.itemType, amount = item.amount });
        }
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
