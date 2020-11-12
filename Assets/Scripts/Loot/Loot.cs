using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Loot : MonoBehaviour
{
    [SerializeField] private float range;
    private bool isClickable = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (DetectPlayer())
            {
                LootManager.MyInstance.PopWindow();
                Destroy(gameObject);
            }
        }
    }

    private bool DetectPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, range);
        if (hit != null && hit.tag == "Player")
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
