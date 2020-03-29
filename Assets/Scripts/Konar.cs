using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Konar : MonoBehaviour
{
    // Sprawdzanie podłoża
    public Transform groundCheck;
    public bool grounded;
    float groundRadius = 1f;
    public LayerMask whatIsGround;

    //zmienne poruszania się, fizyki i animacja
    bool facingRight = true;
    public float movesSpeed;
    public Rigidbody2D rigid;
    Animator anim;
    public bool stay = true;


    //życie i cel ataku
    public int maxHealth = 40;
    public int curHealth;
    public Transform target;
    private Collider2D colision;
    private bool dead = false;

    public int damage = 20;
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        curHealth = maxHealth;
        colision = GetComponent<Collider2D>();
    }
    //sprawdzanie podłoża oraz nadawanie przeciwnikowi ruchu
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Stay", stay);
    }
    //sprawdzanie czy krzak jeszcze żyje, jeśli nie zostaje usunięty
    void Update()
    {
        if (curHealth <= 0 && !dead)
        {
            Dead();
            dead = true;
        }

    }
    //Obracananie przeciwnika
    public void Flip()
    {
        facingRight = !facingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        movesSpeed *= -1;
    }
    //przyjmowanie obrażeń
    public void Damage(int damage)
    {
        curHealth -= damage;
    }
    //funkcja umierania
    void Dead()
    {
        anim.SetBool("Dead", true);
        Destroy(gameObject);
    }
}
