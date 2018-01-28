using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Destructable : NetworkBehaviour
{

	private bool hasExploded;

	public GameObject[] explosionPrefabs;

	void Start()
	{
		hasExploded = false;
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.GetComponent<Destructable>() == null &&
			other.gameObject.GetComponent<FadeAway>() == null)
		{
			CmdBreak ();
		}
	}

	public override void OnNetworkDestroy()
	{
	}

	[Command]
	public void CmdBreak()
	{
		if (!hasExploded)
		{
			foreach (GameObject g in explosionPrefabs)
			{
				GameObject s = Instantiate (g, transform.position, transform.rotation);

				s.gameObject.GetComponent<Rigidbody> ().velocity = (gameObject.GetComponent<Rigidbody> ().velocity);
			}
		}
		hasExploded = true;
		Destroy (gameObject);
	}
}
