using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Arrow,
        HealthPotion,
        ManaPotion,
        Coin
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Arrow:            return ItemAssets.MyInstance.arrowSprite;
            case ItemType.HealthPotion:     return ItemAssets.MyInstance.healthPotionSprite;
            case ItemType.ManaPotion:       return ItemAssets.MyInstance.manaPotionSprite;
            case ItemType.Coin:             return ItemAssets.MyInstance.coinSprite;
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Arrow: 
            case ItemType.HealthPotion: 
            case ItemType.ManaPotion: 
            case ItemType.Coin:
                return true; 
        }
    }
}
