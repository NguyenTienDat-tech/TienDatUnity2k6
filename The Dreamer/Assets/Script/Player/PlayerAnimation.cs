using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerControl player;
    private Animator animator;
    [SerializeField] Camera camera;


    private void Start()
    {
        player = GetComponent<PlayerControl>();
        animator = GetComponent<Animator>();
    }

    private void AnimationMove()
    {
        float moveX = player.movement.x;

        bool isMoving = player.movement.sqrMagnitude > 0.1f; //sqrMagnitude nhanh hơn magnitude vì không cần tính căn bậc 2

        if (isMoving)
        {
            animator.SetFloat("moveX", moveX);
        }
        animator.SetBool("isRun", isMoving);
    }

    private void AnimationAttack()
    {
        Vector3 Mouse = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = Mouse - transform.position;

        direction.Normalize(); //chuẩn hóa vector về độ dài bằng 1, -1

        animator.SetFloat("moveX", direction.x);

    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AnimationAttack();
        }
        else
        {
            AnimationMove();
        }
            
    }
}
