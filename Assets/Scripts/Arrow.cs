﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;

    private Transform target;

    [SerializeField]
    private float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = PlayerScript.MyInstance.MyAttack.MyTarget;

        Destroy(gameObject, 1f);
    }

    private void FixedUpdate()
    {
        Vector2 direction = target.position - transform.position;

        rb.velocity = direction.normalized * speed;

        //Rotate arrow to direct the point towards the target
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(Mathf.Floor(Random.Range(PlayerScript.MyInstance.MyAttack.MyMinAtk, PlayerScript.MyInstance.MyAttack.MyMaxAtk)));
            Destroy(gameObject);
        }
    }
}
