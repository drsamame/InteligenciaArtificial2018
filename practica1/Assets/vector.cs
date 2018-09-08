using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vector : MonoBehaviour {

    // Use this for initialization
    Vector3 velocity = new Vector3(0.3f, 0f, 0f);
    Vector3 gravity = new Vector3(-6f, -3f, 0f); 
    float t = 0f;
	void Start () {
		
	}
	
	void Update () {
        //velocity += gravity;
        //transform.position += velocity;

        t += 0.01f; 
        transform.position = Vector3.Lerp(new Vector3(0.3f, 0f, 0f), new Vector3(-6f, -3f, 0f), t);
        
	}
}
