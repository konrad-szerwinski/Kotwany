using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//uniwersalny skrypt dla dwóch różnych "colliders"
public class KonarMove : MonoBehaviour {
    public Konar konar;

    //zmienna "konar" dostaje zmienne oraz metody swojego "rodzica"
    //oznacza to że każda zmienna publiczna i każda metoda publiczna
    //zawarta w skrypcie "Konar.cs" może zostać odczytana
    //w tym skrypcie
    void Start () {
        konar = gameObject.GetComponentInParent<Konar>();
	}
    //służy do wykrywania gracza. Jeśli jest on za postacią
    //obraca się ku niemu, a jeśli jest przed nim
    //podąża w jego kierunku
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(gameObject.name == "Back" && collision.CompareTag("Player"))
        {
            konar.Flip();
        }
        if (gameObject.name == "Front" && konar.grounded && collision.CompareTag("Player"))
        {
            konar.stay = false;
            konar.rigid.velocity = new Vector2(konar.movesSpeed, konar.rigid.velocity.y);
        }
    }
    //funkcja pozwalająca na przełączenie animacji.
    //Jeśli konar nie widzi gracza, przestaje chodzić.
    //Jest to funkcja wyjścia z collidera (po polski zderzak...
    //właśnie dlatego jest tu używane angielskie słowo)
    private void OnTriggerExit2D(Collider2D collision)
    {
        konar.stay = true;
    }
}
