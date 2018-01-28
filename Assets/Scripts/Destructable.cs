using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Destructable : NetworkBehaviour
{

	private bool hasExploded;

	private float delay;

	public GameObject[] explosionPrefabs;

	void Start()
	{
		hasExploded = false;
		delay = 0.01f;
	}

	void Update()
	{
		if (hasExploded)
		{
			delay -= Time.deltaTime;
			if (delay < 0)
				Destroy (gameObject);
		}
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
		CmdBreak ();
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
	}
}
