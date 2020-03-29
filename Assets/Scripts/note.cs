using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note : MonoBehaviour
{
    private bool floatup;
    public float time = 1f;
    bool waitActive = false;
    public GameObject partner;
    Gate gate;
    // Use this for initialization
    void Start()
    {
        gate = partner.GetComponent<Gate>();
        floatup = false;
    }
    //funkcja pozwala na umieszczenie opóźnienia w wykonywaniu skryptu
    IEnumerator Wait(float duration)
    {
        waitActive = true;
        //Debug.Log("Start Wait() function. The time is: " + Time.time);
        //Debug.Log("Float duration = " + duration);
        yield return new WaitForSeconds(duration);
        //Debug.Log("End Wait() function and the time is: " + Time.time);
        waitActive = false;
        floatup = !floatup;
    }
    //wywoływane są funkce sprawiające że notatka "lewituje"
    private void Update()
    {
        if (floatup)
            floatingUp();
        else if (!floatup)
            floatingDown();
    }
    //unoszenie się do góry
    private void floatingUp()
    {
        transform.position = new Vector2(
           x: transform.position.x,
           y: transform.position.y + 0.4f * Time.deltaTime
           );
        if (!waitActive)
            StartCoroutine(Wait(time));
    }
    //opadanie
    private void floatingDown()
    {
        transform.position = new Vector2(
           x: transform.position.x,
           y: transform.position.y - 0.4f * Time.deltaTime
           );
        if (!waitActive)
            StartCoroutine(Wait(time));
    }

    //Funkcja uruchamiająca się wtedy, gdy gracz się z nią zetknie
    //włącza ona przejście na następny poziom oraz wyłącza notatkę z gry
    //by nie była widoczna
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gate.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}