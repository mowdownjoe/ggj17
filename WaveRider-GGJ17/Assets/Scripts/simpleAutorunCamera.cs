using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleAutorunCamera : MonoBehaviour
{

    private Vector3 offset;
    public Transform player;
    
    // Use this for initialization
	void Start ()
	{
	    offset = transform.position - player.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 combo = player.position + offset;
        transform.position = new Vector3(combo.x, transform.position.y, transform.position.z);
	}
}
