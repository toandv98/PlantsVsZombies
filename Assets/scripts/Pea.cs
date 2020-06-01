using UnityEngine;

public class Pea : MonoBehaviour
{
    private Animator animator;

    private float hp;
    private float damage;
    public bool isTimer;

    void Start()
    {
        hp = Constants.PEA_HP;
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Shoot(true);
        DestroyPea();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("eat!!!!!" + collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("zombie_0"))
        {
            damage = Constants.ZOMBIE_0_DAMAGE;
            isTimer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isTimer = false;
    }

    private void DestroyPea()
    {
        if (isTimer)
        {
            hp -= damage * Time.deltaTime;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Shoot(bool b)
    {
        animator.SetBool("isIdle", b);
        animator.SetBool("isShooter", !b);
    }
}