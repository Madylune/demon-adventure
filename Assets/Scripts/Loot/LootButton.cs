using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LootButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private Text title;

    public Image MyIcon { get => icon; }
    public Text MyTitle { get => title; }
    public Item MyLoot { get; set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerScript.MyInstance.MyInventory.AddItem(MyLoot);
        Destroy(gameObject);
    }
}
