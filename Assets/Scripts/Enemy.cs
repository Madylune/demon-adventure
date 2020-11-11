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
            CombatTextManager.MyInstance.CreateText(transform.position, amount.ToString(), CombatTextType.DAMAGE, false);
        }
        healthBar.SetHealth(currentHealth);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
