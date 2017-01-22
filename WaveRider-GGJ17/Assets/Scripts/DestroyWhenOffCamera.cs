using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenOffCamera : MonoBehaviour
{

    public float delay = 1f;
    private Camera mainCamera;
    private bool setToDestroy = false;
    
    // Use this for initialization
	void Start () {
		mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float objectX = mainCamera.WorldToViewportPoint(gameObject.transform.position).x;
        if (!setToDestroy && objectX < 0)
	    {
	        setToDestroy = true;
            Destroy(gameObject,delay);
	    }
	}
}
