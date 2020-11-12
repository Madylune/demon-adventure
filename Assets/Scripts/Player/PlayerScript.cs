using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private string username;
    [SerializeField] private float currentHealth, maxHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Text usernameText;
    [SerializeField] private UI_Inventory uiInventory;

    private PlayerMovement movement;
    private PlayerAttack attack;
    private Inventory inventory;

    private static PlayerScript instance;

    public static PlayerScript MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerScript>();
            }
            return instance;
        }
    }

    public PlayerMovement MyMovement { get => movement; set => movement = value; }
    public PlayerAttack MyAttack { get => attack; set => attack = value; }
    public Inventory MyInventory { get => inventory; set => inventory = value; }

    private void Awake()
    {
        MyInventory = new Inventory();
        uiInventory.SetInventory(MyInventory);
    }

    private void Start()
    {
        MyMovement = GetComponent<PlayerMovement>();
        MyAttack = GetComponent<PlayerAttack>();

        currentHealth = maxHealth;
        healthBar.Initialize(currentHealth, maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Heal(100);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            MyInventory.AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            MyInventory.AddItem(new Item { itemType = Item.ItemType.Coin, amount = 1 });
        }
    }

    public void TakeDamage(int damage)
    {
        if ((currentHealth - damage) < 0)
        {
            currentHealth = 0;
            //Die()
        }
        else
        {
            currentHealth -= damage;
            CombatTextManager.MyInstance.CreateText(transform.position, damage.ToString(), CombatTextType.DAMAGE, false);
        }
        healthBar.SetHealth(currentHealth);
    }

    public void Heal(int amount)
    {
        if ((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

        healthBar.SetHealth(currentHealth);
        CombatTextManager.MyInstance.CreateText(transform.position, amount.ToString(), CombatTextType.HEAL, false);
    }

    public void Die()
    {

    }
}
