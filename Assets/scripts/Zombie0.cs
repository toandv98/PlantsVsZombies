using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie0 : MonoBehaviour
{
    private Animator animator;

    private float speed = Constants.NORMAL_SPEED;
    private float hp = Constants.ZOMBIE_0_HP;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    animator.SetBool("isWalk", false);
        //    animator.SetBool("isHurt", true);
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    animator.SetBool("isHurt", false);
        //    animator.SetBool("isDead", true);
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    Destroy(gameObject);
        //}
        transform.Translate(Vector3.left * (speed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("isWalk", false);
        animator.SetBool("isAttack", true);
        speed = 0;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("isAttack", false);
        animator.SetBool("isWalk", true);
        speed = Constants.NORMAL_SPEED;
    }
}
