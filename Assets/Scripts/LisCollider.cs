using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LisCollider : MonoBehaviour {
    //zmienne globalne
    Lis lis;
    bool waitActive = false;
    // Use this for initialization
    void Start () {
        lis = gameObject.GetComponentInParent<Lis>();
	}
    //jeśli wykryta postać to nie gracz, nie collider konaru i może się poruszać
    //to collider pozwala na odwócenie lisa
    //a jeśli to gracz, turla się dalej ale zadaje obrażenia
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") && !collision.CompareTag("Collider") && !lis.stay)
        {
            if(waitActive == false)lis.Flip();
            Wait(0.2f);
        }
        if (collision.CompareTag("Player") && !lis.stay)
        {
            collision.SendMessageUpwards("Damage", lis.damage);
        }
    }
    //uniwersalna fuknkcja pozwalająca opóźnić wykonywanie skryptu
    IEnumerator Wait(float duration)
    {
        waitActive = true;
        //Debug.Log("Start Wait() function. The time is: " + Time.time);
        //Debug.Log("Float duration = " + duration);
        yield return new WaitForSeconds(duration);
        //Debug.Log("End Wait() function and the time is: " + Time.time);
        waitActive = false;
    }
}
