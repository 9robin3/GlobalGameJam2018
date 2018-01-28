using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Destructable : NetworkBehaviour
{

	public GameObject[] explosionPrefabs;

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.GetComponent<Destructable>() == null &&
			other.gameObject.GetComponent<FadeAway>() == null)
		{
			CmdBreak ();
		}
	}

	[Command]
	public void CmdBreak()
	{
		foreach (GameObject g in explosionPrefabs)
		{
			GameObject s = Instantiate (g, transform.position, transform.rotation);
			NetworkServer.Spawn (s);

			s.gameObject.GetComponent<Rigidbody> ().velocity = (gameObject.GetComponent<Rigidbody> ().velocity);
		}

		Destroy (gameObject);
	}
}
