using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3;

    public int facingIndex = 0;

    private Vector3 targetPosition;

    private bool isMoving = false;

    private Rigidbody2D rb;

    private Animator anim;

    private PlayerAttack playerAttack;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPosition();
        }

        if (isMoving && !playerAttack.IsAttacking)
        {
            OnClickMoving();
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }

    void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;
        isMoving = true;

        //RaycastHit2D hit = Physics2D.Raycast(targetPosition, Vector2.zero);
        //if (hit.transform != null)
        //{
        //    if (hit.transform.tag == "Ground")
        //    {
        //        targetPosition.z = transform.position.z;
        //        isMoving = true;
        //    }
        //}
    }

    void OnClickMoving()
    {
        anim.SetBool("IsMoving", true);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Mathf.Round(targetPosition.x) > Mathf.Round(transform.position.x)) //Right
        {
            anim.SetFloat("MoveX", 1);
            anim.SetFloat("MoveY", 0);
            facingIndex = 3;
        }
        if (Mathf.Round(targetPosition.x) < Mathf.Round(transform.position.x)) //Left
        {
            anim.SetFloat("MoveX", -1);
            anim.SetFloat("MoveY", 0);
            facingIndex = 2;
        }
        if (Mathf.Round(targetPosition.y) > Mathf.Round(transform.position.y)) //Up
        {
            anim.SetFloat("MoveY", 1);
            anim.SetFloat("MoveX", 0);
            facingIndex = 1;
        }
        if (Mathf.Round(targetPosition.y) < Mathf.Round(transform.position.y)) //Down
        {
            anim.SetFloat("MoveY", -1);
            anim.SetFloat("MoveX", 0);
            facingIndex = 0;
        }

        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Environment")
        {
            isMoving = false;
        }
    }
}
