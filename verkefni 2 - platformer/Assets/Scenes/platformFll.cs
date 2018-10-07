using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformFll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 currentVelocity = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = new Vector2(currentVelocity.x, -0.5f);
    }

    

};
