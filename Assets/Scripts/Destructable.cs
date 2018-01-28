using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{

	public GameObject[] explosionPrefabs;

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.GetComponent<Destructable>() == null &&
			other.gameObject.GetComponent<FadeAway>() == null)
		{
			foreach (GameObject g in explosionPrefabs)
			{
				GameObject s = Instantiate (g, transform.position, transform.rotation);
				s.gameObject.GetComponent<Rigidbody> ().velocity = (gameObject.GetComponent<Rigidbody> ().velocity);
			}

			Destroy (gameObject);
		}
	}
}
