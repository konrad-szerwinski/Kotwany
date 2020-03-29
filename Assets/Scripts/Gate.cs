using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    //wyłącza cały obiekt, by inny obiekt mógł go włączyć
    //po spełnieniu odpowienich warunków
    void Start()
    {
        gameObject.SetActive(false);
    }
}