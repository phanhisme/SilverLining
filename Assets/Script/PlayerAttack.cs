using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Attack()
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage;

    public Animator anim;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    void Attack()
    {
        anim.SetTrigger("isAttacking");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); //detect enemies

        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log("hitting " + enemy.name);
            //enemy.GetComponent<Enemy>().enemyTakingDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
