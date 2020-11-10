using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private PlayerMovement movement;
    private PlayerAttack attack;

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

    private void Start()
    {
        MyMovement = GetComponent<PlayerMovement>();
        MyAttack = GetComponent<PlayerAttack>();
    }
}
