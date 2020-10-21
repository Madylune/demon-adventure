using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 3;

    [SerializeField]
    public int facingIndex = 2;

    public Rigidbody2D rb;

    private Vector3 targetPosition;

    private bool isMoving = false;

    [SerializeField]
    public Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPosition();
        }
        if (isMoving)
        {
            OnClickMoving();
        }
    }

    void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;

        isMoving = true;
    }

    void OnClickMoving()
    {
        anim.SetBool("IsMoving", true);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Mathf.Round(targetPosition.x) > Mathf.Round(transform.position.x))
        {
            anim.SetFloat("MoveX", 1);
            anim.SetFloat("MoveY", 0);
        }
        if (Mathf.Round(targetPosition.x) < Mathf.Round(transform.position.x))
        {
            anim.SetFloat("MoveX", -1);
            anim.SetFloat("MoveY", 0);
        }
        if (Mathf.Round(targetPosition.y) > Mathf.Round(transform.position.y))
        {
            anim.SetFloat("MoveY", 1);
            anim.SetFloat("MoveX", 0);
        }
        if (Mathf.Round(targetPosition.y) < Mathf.Round(transform.position.y))
        {
            anim.SetFloat("MoveY", -1);
            anim.SetFloat("MoveX", 0);
        }

        if (transform.position == targetPosition)
        {
            isMoving = false;
            anim.SetBool("IsMoving", false);
        }
    }
}
