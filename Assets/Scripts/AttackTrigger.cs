using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {
    //zmienne globalne
    public int damage = 20;

    //funkcja zadaje obrazenia obiektom z tagiem "Enemy"
    //sprawdza, czy obiekt który jest atakowany posiada
    //podany wyżej tag, a następnie wywołuje u niego 
    //funkcję zadającą obrazenia
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Enemy"))
        {
            collision.SendMessageUpwards("Damage", damage);
        }
    }
}
