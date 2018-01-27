using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTransmitter : MonoBehaviour {

	public GameObject laserBeam;

	private List<Transform> connectionPoints;

	private List<LineRenderer> beams;

	// Use this for initialization
	void Start ()
	{
		connectionPoints = new List<Transform> ();

		beams = new List<LineRenderer> ();
	}


	void OnDestroy()
	{
		foreach(LineRenderer r in beams)
			Destroy(r.gameObject);

		foreach (GameObject g in GameObject.FindGameObjectsWithTag("LaserSender"))
		{
			LaserTransmitter sender = g.GetComponent<LaserTransmitter> ();
			for(int i=0; i<sender.connectionPoints.Count; i++)
			{
				if (sender.connectionPoints [i] == transform)
				{
					sender.connectionPoints.RemoveAt (i);
					Destroy (sender.beams [i].gameObject);
					sender.beams.RemoveAt (i);
					break;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < beams.Count; i++)
		{
			beams [i].SetPosition (1, connectionPoints [i].position - transform.position);
		}

		foreach (GameObject g in GameObject.FindGameObjectsWithTag("LaserSender"))
		{
			if (g != gameObject && Random.value < 0.01)
			{
				connectionPoints.Add (g.transform);

				GameObject beam = (GameObject)Instantiate (laserBeam, transform.position, Quaternion.identity);

				beam.transform.parent = transform;

				beams.Add (beam.GetComponent<LineRenderer> ());
			}
		}
	}
}
