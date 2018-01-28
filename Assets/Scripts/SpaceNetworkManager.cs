using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpaceNetworkManager : MonoBehaviour {

	public enum StartState
	{
		StartAsHost,
		StartAsClient
	}

	public StartState startState;

	NetworkManager manager;

	void Start () {
		manager = gameObject.GetComponent<NetworkManager> ();
		switch(startState)
		{
		case StartState.StartAsHost:
			manager.StartHost ();
			break;
		case StartState.StartAsClient:
			manager.StartClient ();
			break;
		}
	}

	void Update () {
		
	}
}
