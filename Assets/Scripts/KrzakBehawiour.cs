using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrzakBehawiour : MonoBehaviour {
    // Sprawdzanie podłoża
    public Transform groundCheck;
    bool grounded;
    float groundRadius = 1f;
    public LayerMask whatIsGround;

    //zmienne poruszania się, fizyki i animacja
    bool facingRight = true;
    public float movesSpeed;
    Rigidbody2D rigid;
    Animator anim;

    //życie i cel ataku
    public int maxHealth = 20;
    public int curHealth;
    public Transform target;
    private Collider2D colision;
    private bool dead = false;
    public int damage = 20;

    //hermetuzacja pola movesSpeed miała pozwolić na
    //dostęp do niej poprzez inne skrypty, ale udało
    //się to za pomocą innej metody
    public float MovesSpeed
    {
        get
        {
            return movesSpeed;
        }

        set
        {
            movesSpeed = value;
        }
    }
    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        curHealth = maxHealth;
        colision = GetComponent<Collider2D>();
	}
    //sprawdzanie podłoża oraz nadawanie przeciwnikowi ruchu
    void FixedUpdate(){
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        rigid.velocity = new Vector2(MovesSpeed, rigid.velocity.y);
        if (!grounded)
            Flip();
    }
    //sprawdzanie czy krzak jeszcze żyje, jeśli nie zostaje usunięty
    void Update () {
        if (curHealth <= 0 && !dead){
            Dead();
            dead = true;
        }

	}
    //Obracananie przeciwnika
    public void Flip(){
        facingRight = !facingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        MovesSpeed *= -1;
    }
    //przyjmowanie obrażeń
    public void Damage(int damage){
        curHealth -= damage;
    }
    //funkcja umierania, przesyła Animatorowi zmienne by mógł on
    //przełączyć się między animacją chodzenia a animacją umierania
    //a następnie usuwa komponenty zawarte w obiekcie by 
    //nie możliwa była jakakolwiek interakcja podczas "umierania"
    //a na końcu usuwa cały obiekt.
    void Dead(){
        anim.SetBool("Dead", true);
        MovesSpeed = 0;
        if (colision.enabled)
            Destroy(rigid);
        colision.enabled = false;
        Debug.Log("Animacja umierania krzaczka");
        Destroy(gameObject, 1.3f);
    }
}