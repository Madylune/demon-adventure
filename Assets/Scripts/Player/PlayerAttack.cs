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
    private float minAtk = 30f, maxAtk = 50f;

    private PlayerMovement playerMovement;
    private Animator anim;
    private Transform target;

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
}
