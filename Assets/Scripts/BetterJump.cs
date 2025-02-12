﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {
    Rigidbody2D rigit;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    // Use this for initialization
    void Awake () {
        rigit = GetComponent<Rigidbody2D>();
 	}
	
	// Update is called once per frame
	void Update () {
        if (rigit.velocity.y < 0)
        {
            rigit.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }
    }
}
