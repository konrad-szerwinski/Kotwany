using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpAll : MonoBehaviour {
    //zmienne globalne
    Renderer[] renderers;
    public Transform target;
    public float showOnDistance;
    // Use this for initialization
    void Start () {
        renderers = GetComponentsInChildren<Renderer>();

    }
	
	//jeśli dystans będzie odpowieni, zostanie wyświetlona
    //cała chmurka z napisem
	void Update () {
        foreach (var r in renderers)
        {
            if (Vector2.Distance(transform.position, target.position) < showOnDistance)
                r.enabled = true;
            else
                r.enabled = false;
        }
    }
}
