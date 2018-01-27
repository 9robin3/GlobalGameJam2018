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
			if (g != gameObject && Random.value < 0.005 && !connectionPoints.Contains(g.transform))
			{
				connectionPoints.Add (g.transform);

				GameObject beam = (GameObject)Instantiate (laserBeam, transform.position, Quaternion.identity);

				Color c = Random.ColorHSV (0f, 1f, 1f, 1f, 0.5f, 1f);

				LineRenderer line = beam.GetComponent<LineRenderer> ();

				line.startColor = c;
				line.endColor = c;

				beams.Add (line);

				beam.transform.parent = transform;

				break;
			}
		}

		if (Random.value < 0.005 && beams.Count > 0)
		{
			int i = Random.Range (0, beams.Count);

			connectionPoints.RemoveAt (i);
			Destroy (beams [i].gameObject);
			beams.RemoveAt (i);
		}
	}
}
