using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtackKonar : MonoBehaviour {
    //zadeklarowane zmienne globalne
    public int damage = 34;
    Konar konar;
    //zmienna "konar" dostaje zmienne oraz metody swojego "rodzica"
    //oznacza to że każda zmienna publiczna i każda metoda publiczna
    //zawarta w skrypcie "Konar.cs" może zostać odczytana
    //w tym skrypcie
    private void Start()
    {
        konar = gameObject.GetComponentInParent<Konar>();
    }
    //pozwala sprawdzić, czy kolizja następuje z graczem
    //czy z przeciwnikiem. jeśli jest to gracz, wysyła dla niego
    //obrażenia, jeśli przeciwnik, nie robi nic (w celach debugowych)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("PLAYER");
            collision.SendMessageUpwards("Damage", damage);
        }
        else if (collision.CompareTag("Enemy"))
        {
            //Debug.Log("ENEMY");
        }
    }
}
