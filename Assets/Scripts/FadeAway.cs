using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour {

	private float life;

	// Use this for initialization
	void Start () {
		life = Random.Range(8f,10f);
	}
	
	// Update is called once per frame
	void Update () {
		life -= Time.deltaTime;
		if (life < 0)
			Destroy (gameObject);
	}
}
