using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private string title;

    [SerializeField]
    private float level, minAtk, maxAtk, currentHealth, maxHealth = 1000;

    [SerializeField]
    private HealthBar healthBar;

    [SerializeField]
    private Text titleText;

    void Start()
    {
        titleText.text = title + " (" + level + ")";
        currentHealth = maxHealth;
        healthBar.Initialize(currentHealth, maxHealth);
    }

    public void TakeDamage(float amount)
    {
        if ((currentHealth - amount) < 0)
        {
            currentHealth = 0;
            Die();
        }
        else
        {
            currentHealth -= amount;

            bool critChance = Random.Range(0, 5) < 1 ? true : false;
            CombatTextManager.MyInstance.CreateText(transform.position, amount.ToString(), CombatTextType.HIT, critChance);
        }
        healthBar.SetHealth(currentHealth);
    }

    private void Die()
    {
        LootManager.MyInstance.InstantiateRelic(transform);
        Destroy(gameObject);
    }
}
