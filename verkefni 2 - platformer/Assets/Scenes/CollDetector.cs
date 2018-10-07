using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// þetta scrip sér um að allt sem dettur ofan í vatið verði eytt, bæði platform og player

public class CollDetector : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
       
        if (coll.gameObject)
        {
            Destroy(coll.collider.transform.root.gameObject);

        }

    }
}
