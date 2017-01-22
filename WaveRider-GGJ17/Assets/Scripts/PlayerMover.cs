using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float moveRate = 3.5f;
    public float changeRate = 0.1f;
    public float minRate = .5f;
    public float maxRate = 12f;
    public float maxHeight = 4f;
    public bool movingUp;
    public float worldMove = .5f;

	// Use this for initialization
	void Start ()
	{
	    rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.LeftArrow)){
	        moveRate -= changeRate;
	    }
	    if (Input.GetKey(KeyCode.RightArrow)){
	        moveRate += changeRate;
	    }
	    moveRate = Mathf.Clamp(moveRate, minRate, maxRate);
	}

    void FixedUpdate() //For Physics!
    {
        if (rb2d.position.y >= maxHeight)
        {
            movingUp = false;
        }
        if (rb2d.position.y <= -maxHeight)
        {
            movingUp = true;
        }
        if (movingUp) {
            //rb2d.velocity = Vector2.up * moveRate;
            rb2d.velocity = new Vector2(worldMove, moveRate);
        } else {
            //rb2d.velocity = Vector2.down * moveRate;
            rb2d.velocity = new Vector2(worldMove, -moveRate);
        }

    }

    
}
