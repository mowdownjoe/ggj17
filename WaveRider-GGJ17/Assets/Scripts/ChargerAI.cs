using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerAI : MonoBehaviour
{

    public float timeToCharge = .5f;
    public float force = .75f;
    private float timer = 0;
    private Rigidbody2D body;
    
    // Use this for initialization
	void Start ()
	{
	    body = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timer += Time.deltaTime;
	}

    void FixedUpdate()
    {
        if (timer >= timeToCharge)
        {
            body.AddForce(Vector2.left*force);
        }
    }
}
