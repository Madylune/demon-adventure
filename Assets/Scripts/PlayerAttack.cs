using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject arrowPrefab;

    [SerializeField]
    private float atkSpeed, atkDirection;

    [SerializeField]
    private Transform[] exitPoints;

    private PlayerMovement playerMovement;
    private Animator anim;
    private Transform target;

    private bool isAttacking = false;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
            if (hit.transform != null)
            {
                if (hit.transform.tag == "Enemy" && !isAttacking)
                {
                    target = hit.transform;
                    StartCoroutine(Attack());
                }
            }

            target = null;
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        anim.SetBool("IsAttacking", true);

        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(atkSpeed, atkDirection);

        yield return new WaitForSeconds(1);

        Destroy(arrow);
        StopAttack();
    }



    private void StopAttack()
    {
        isAttacking = false;
        anim.SetBool("IsAttacking", false);
    }
}
