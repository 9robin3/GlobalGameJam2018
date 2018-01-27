using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakApart : MonoBehaviour {

	// Use this for initialization
	void Start () {

		for (int i = 0; i < transform.childCount; i++)
		{
			Transform c = transform.GetChild (i);
			c.gameObject.GetComponent<Rigidbody> ().AddForce ((c.position - transform.position)*5);
		}

		transform.DetachChildren ();
		Destroy (gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
