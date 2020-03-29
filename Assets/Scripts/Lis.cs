using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lis : MonoBehaviour {
    //zmienne globalne
    public bool stay = true;
    public float moveSpeed;
    public Rigidbody2D rigid;
    Animator anim;
    public int maxHealth = 9999999;
    public int curHealth;
    public int damage = 50;
    
    // Use this for initialization
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        curHealth = maxHealth;
    }

    //jeśli lis nie stoi w miejscu, czyli jeśli zobaczy gracza
    //zaczyna się turlać w jego stronę
    void FixedUpdate () {
        anim.SetBool("Stay", stay);
        if(stay == false)
            rigid.velocity = new Vector2(moveSpeed, rigid.velocity.y);
    }

    //funkcja obracająca obiekt po osi X
    public void Flip()
    {
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        moveSpeed *= -1;
    }
}

