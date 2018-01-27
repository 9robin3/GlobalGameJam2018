using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour {

	public float lifeTime;

	private float life;

	void Start () {
		life = lifeTime;
	}
	
	// Update is called once per frame
	void Update () {
		life -= Time.deltaTime;

		if (life <= 0)
			Destroy (gameObject);
	}
}
