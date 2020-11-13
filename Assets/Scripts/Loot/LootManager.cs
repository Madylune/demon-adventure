using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    private static LootManager instance;

    public static LootManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LootManager>();
            }
            return instance;
        }
    }

    [SerializeField] private GameObject relicPrefab;
    [SerializeField] private GameObject lootWindow;
    [SerializeField] private Transform mainCanvas;

    public void InstantiateRelic(Transform corpse)
    {
        Instantiate(relicPrefab, corpse.position, corpse.rotation);
    }

    public void PopWindow()
    {
        Instantiate(lootWindow, mainCanvas);
    }
}
