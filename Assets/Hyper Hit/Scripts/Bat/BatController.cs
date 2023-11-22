using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform hitPoint;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask ballLayer;

    public float speed = 10.0f;

    private void Update()
    {
        // Detect user input
        if (Input.GetMouseButtonDown(0))
        {
            HitBall();
        }
    }

    private void HitBall()
    {
        BatHit();
    }

    public void BatHit()
    {
        animator.SetTrigger("Hit");
    }
}
