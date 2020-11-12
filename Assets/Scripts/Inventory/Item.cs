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
            case ItemType.Arrow:
                return ItemsManager.MyInstance.arrowSprite;
            case ItemType.HealthPotion:
                return ItemsManager.MyInstance.healthPotionSprite;
            case ItemType.ManaPotion:
                return ItemsManager.MyInstance.manaPotionSprite;
            case ItemType.Coin:
                return ItemsManager.MyInstance.coinSprite;
            default:
                return null;
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            case ItemType.Arrow: 
            case ItemType.HealthPotion: 
            case ItemType.ManaPotion: 
            case ItemType.Coin:
                return true;
            default:
                return false;
        }
    }

    public bool IsUseable()
    {
        switch (itemType)
        {
            case ItemType.HealthPotion:
            case ItemType.ManaPotion:
                return true;
            case ItemType.Arrow:
            case ItemType.Coin:
            default:
                return false;
        }
    }
}
