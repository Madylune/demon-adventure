using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    private static ItemsManager instance;

    public static ItemsManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ItemsManager>();
            }
            return instance;
        }
    }

    public Sprite arrowSprite;
    public Sprite healthPotionSprite;
    public Sprite manaPotionSprite;
    public Sprite coinSprite;
}
