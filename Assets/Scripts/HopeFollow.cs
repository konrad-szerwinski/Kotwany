using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopeFollow : MonoBehaviour {
    public float speed;
    public Transform target;
    public float StopiingDistance;
    public float StartFollowingDistance;
    private void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        if(Vector2.Distance(transform.position, target.position) < StartFollowingDistance){
            if(Vector2.Distance(transform.position, target.position) > StopiingDistance){
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }
}
