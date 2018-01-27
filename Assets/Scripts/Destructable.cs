using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{

	public GameObject[] explosionPrefabs;

	void OnTriggerEnter () {
		foreach (GameObject g in explosionPrefabs)
		{
			Instantiate (g, transform.position, transform.rotation);
		}

		Destroy (gameObject);
	}
}
