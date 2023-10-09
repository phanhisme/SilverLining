using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator anim;

    //Health()
    [SerializeField] private int maxHealth = 5;
    [SerializeField] public int currentHealth { get; private set; } //can get this data from other scripts but can only change it in this script

    public Animator panelAnim;
    //private bool isDead;

    void Awake()
    {
        //set health
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            anim.SetTrigger("isDead");
            panelAnim.GetComponent<Animator>().enabled = true;
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().isKinematic = true;
        }

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    Health(1);
        //}
    }

    public void Health(int damageTaken)
    {
        //currentHealth = Mathf.Clamp(currentHealth - damageTaken, 0, maxHealth);
        currentHealth -= damageTaken;
        if (currentHealth >= 0)
        {
            anim.SetTrigger("isHurted");

        }
    }
}
