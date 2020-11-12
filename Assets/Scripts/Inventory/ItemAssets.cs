using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets MyInstance { get; private set; }

    private void Awake()
    {
        MyInstance = this;
    }

    public Sprite arrowSprite;
    public Sprite healthPotionSprite;
    public Sprite manaPotionSprite;
    public Sprite coinSprite;
}
