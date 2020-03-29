using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour {
    //zmienne globalne
    public int damage = 20;
    KrzakBehawiour krzak;
    //zmienna "krzak" dostaje zmienne oraz metody swojego "rodzica"
    //oznacza to że każda zmienna publiczna i każda metoda publiczna
    //zawarta w skrypcie "KrzakBehawiour.cs" może zostać odczytana
    //w tym skrypcie
    private void Start()
    {
        krzak = gameObject.GetComponentInParent<KrzakBehawiour>();
    }

    //służy do zadawania obrażeń oraz sprawdzania kolizji 
    //obraca obiekt w przeciwnym kierunku
    //a jeśli napotka gracza, zadaje mu obrażenia
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("PLAYER");
            collision.SendMessageUpwards("Damage", damage);
            krzak.Flip();
        }
        else if (collision.CompareTag("Enemy"))
        {
            //Debug.Log("ENEMY");
            krzak.Flip();
        }
    }
}
