using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject arrowPrefab;

    [SerializeField]
    private Transform[] exitPoints;

    [SerializeField]
    private float minAtk, maxAtk;

    private PlayerMovement playerMovement;
    private Animator anim;
    private Transform target;
    private int facingIndex = 0;
    private Vector3 clickPosition;

    private bool isAttacking = false;

    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }
    public Transform MyTarget { get => target; set => target = value; }
    public float MyMinAtk { get => minAtk; set => minAtk = value; }
    public float MyMaxAtk { get => maxAtk; set => maxAtk = value; }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SetClickPosition();
        }

        if (Input.GetMouseButton(1)) // Mouse still down
        {
            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
            if (hit.transform != null)
            {
                if (hit.transform.tag == "Enemy" && !IsAttacking)
                {
                    MyTarget = hit.transform;
                    StartCoroutine(Attack());
                }
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            MyTarget = null;
        }
    }

    private IEnumerator Attack()
    {
        IsAttacking = true;
        anim.SetBool("IsAttacking", true);
        Instantiate(arrowPrefab, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(1);

        StopAttack();
    }

    private void StopAttack()
    {
        IsAttacking = false;
        anim.SetBool("IsAttacking", false);
    }


    private void SetClickPosition()
    {
        clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPosition.z = transform.position.z;

        SetFacing();
    }

    private void SetFacing()
    {
        if (Mathf.Round(clickPosition.x) > Mathf.Round(transform.position.x)) //Right
        {
            anim.SetFloat("MoveX", 1);
            anim.SetFloat("MoveY", 0);
            facingIndex = 3;
        }
        if (Mathf.Round(clickPosition.x) < Mathf.Round(transform.position.x)) //Left
        {
            anim.SetFloat("MoveX", -1);
            anim.SetFloat("MoveY", 0);
            facingIndex = 2;
        }
        if (Mathf.Round(clickPosition.y) > Mathf.Round(transform.position.y)) //Up
        {
            anim.SetFloat("MoveY", 1);
            anim.SetFloat("MoveX", 0);
            facingIndex = 1;
        }
        if (Mathf.Round(clickPosition.y) < Mathf.Round(transform.position.y)) //Down
        {
            anim.SetFloat("MoveY", -1);
            anim.SetFloat("MoveX", 0);
            facingIndex = 0;
        }
    }
}
