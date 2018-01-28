using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawner : NetworkBehaviour {

	public GameObject[] satellitePrefabs;

	public bool goingRight;

	public Vector3 emitterZone;

	void Update()
	{
		if(Random.Range(0f,1f) < 0.005f)
			CmdSpawnSatellite ();
	}

	[Command]
	public void CmdSpawnSatellite()
	{
		int i = Random.Range (0, satellitePrefabs.Length);

		float x = Random.Range (-0.5f*emitterZone.x, 0.5f*emitterZone.x);
		float y = Random.Range (-0.5f*emitterZone.y, 0.5f*emitterZone.y);
		float z = Random.Range (-0.5f*emitterZone.z, 0.5f*emitterZone.z);

		GameObject sat = Instantiate (satellitePrefabs[i], transform.position+new Vector3(x,y,z), Random.rotation);

		if(goingRight)
			sat.GetComponent<Rigidbody> ().AddForce (Vector3.right*50);
		else
			sat.GetComponent<Rigidbody> ().AddForce (Vector3.left*50);

		NetworkServer.Spawn (sat);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		if(goingRight)
			Gizmos.DrawWireCube (new Vector3(transform.position.x+50+(0.5f*emitterZone.x), transform.position.y, transform.position.z), new Vector3(100f, emitterZone.y, emitterZone.z));
		else
			Gizmos.DrawWireCube (new Vector3(transform.position.x-50-(0.5f*emitterZone.x), transform.position.y, transform.position.z), new Vector3(100f, emitterZone.y, emitterZone.z));

		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube (transform.position, emitterZone);
	}

}
