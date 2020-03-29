using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControllerScript : MonoBehaviour
{
    //zmienne poruszania się, animacji i fizyki;
    public float maxSpeed = 10f;
    public bool facingRight = true;
    private Rigidbody2D rigit;
    Animator anim;
    public float jumpForce = 1000f;

    //Sprawdzanie podłoża
    public Transform groundCheck;
    bool grounded = false;
    float groundRadius = 1f;
    public LayerMask whatIsGround;

    //życie i cel ataku oraz otrzymywania obrażen
    public int maxHealth = 100;
    public int curHealth;
    public Transform target;
    public float damageImpact;

    //przypisuję odpowienie komponenty zmiennym oraz ustawiam życie;
    void Start()
    {
        anim = GetComponent<Animator>();
        rigit = GetComponent<Rigidbody2D>();
        curHealth = maxHealth;
    }
    //odpowiada za poruszanie się i za fizykę, wysyła dane do animatora który po kolei przełącza animacje oraz w zależności od wciskanego przycisku zmieniany jest kierunek patrzenia kota
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", rigit.velocity.y);
        float move = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        rigit.velocity = new Vector2(move * maxSpeed, rigit.velocity.y);
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }

    //sterowanie postacią oraz przeładowanie sceny jeśli życie postaci spadnie do 0
    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.J))
        {
            anim.SetBool("Ground", false);
            rigit.AddForce(new Vector2(0, 25 * jumpForce));
            Vector3 NewPosition = UnityEngine.GameObject.Find("Character").transform.position;
        }
        if (curHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //funkcja odpowiadająca za odwracanie postaci
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //funcka odpowiadająca za wizualny znacznik obrażeń poprzez odrzucenie postaci w kierunku przeciwnym do zwróconego
    public void DamageImpact(float x)
    {
        rigit.AddForce(new Vector2(x*1000f * Time.deltaTime, 10*jumpForce));
        Vector3 NewPosition = UnityEngine.GameObject.Find("Character").transform.position;
    }
    
    //funkcja nasłuchująca odpowiadająca za przyjmowanie obrażeń
    public void Damage(int damage)
    {
        curHealth -= damage;
        if (facingRight)
            DamageImpact(-90f);
        else if (!facingRight)
            DamageImpact(90f);
    }
    
}