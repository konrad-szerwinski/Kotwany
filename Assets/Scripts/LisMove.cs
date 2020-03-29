using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LisMove : MonoBehaviour {
    //zmienne globalne
    public Lis lis;
    Vector2 theScale;
    int count = 0;
    // Use this for initialization
    void Start()
    {
        lis = gameObject.GetComponentInParent<Lis>();
        theScale = lis.transform.localScale;
    }
    //jeśli gracz wejdzie w lewy collider, lis zostaje odwrócony,
    //jego prędkość zostaje zmieniona na ujemną,
    //a następnie zostaje zmieniona zmienna "stay"
    //która odpowiada za powiadomienie Animatora o stanie 
    //obiektu. Czy ma stać w miejscu czy się poruszać.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(count == 0)
        {
            if (gameObject.name == "Left" && collision.CompareTag("Player"))
            {
                lis.moveSpeed *= -1;
                theScale.x *= -1;
            }
            if (collision.CompareTag("Player"))
            {
                count++;
                lis.stay = false;
            }            
        }
    }
}
