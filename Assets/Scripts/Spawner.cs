using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	enum Spawnable {Satellite, Station};

	public GameObject SatellitePrefab;

	public GameObject StationPrefab;

	class SpawnEvent
	{
		public Spawnable toSpawn;
		public float spawnTime;

		public SpawnEvent(Spawnable s, float t)
		{
			toSpawn = s;
			spawnTime = t;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SpawnUnit(Spawnable spawn)
	{
		GameObject prefab = null;
		switch(spawn)
		{
		case Spawnable.Satellite:
			prefab = SatellitePrefab;
			break;
		case Spawnable.Station:
			prefab = StationPrefab;
			break;
		}

		Instantiate(prefab, transform.position, Quaternion.identity);
	}
}
