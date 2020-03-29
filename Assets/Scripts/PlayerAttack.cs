using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    //zmienne globalne
    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCollider = 0.4f;
    public Collider2D attackTrigger;
    Animator anim;
    //indicators
    void Start()
    {
        anim = GetComponent<Animator>();
        attackTrigger.enabled = false;
    }
    //po wciśnięciu klawisza odpowiadającego za atak
    //zostaje włączony collider, który zadaje obrażenia
    //jest też uruchamiana animacja atakowania
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)){
            attacking = true;
            attackTimer = attackCollider;
            attackTrigger.enabled = true;

        }

        if (attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
            anim.SetBool("Attacking", attacking);
        }
        
    }

    
}
