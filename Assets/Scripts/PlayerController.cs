using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    [SerializeField]
    float Speed = 1;
    [SerializeField]
    float rotationStrenght = 1;
    private Vector3 startRot;
    GameObject mainCamera;

	public GameObject ServerPlayer;
	public GameObject signalPrefab;

    private void Start()
    {
        startRot = transform.rotation.eulerAngles;
        mainCamera = Camera.main.gameObject;
        Debug.Log(mainCamera);
    }

    private void Update()
    {
        movement();
    }

    private void movement()
    {
		if (!isLocalPlayer)
			return;
		
        float Vert = Input.GetAxis("Vertical") * Speed;
        float Horz = Input.GetAxis("Horizontal") * Speed;
        float RotVert = Input.GetAxis("Vertical") * rotationStrenght;
        float RotHorz = Input.GetAxis("Horizontal") * rotationStrenght;

		if(Vert != 0 || Horz != 0)
		{
			Rigidbody rigidbody = GetComponent<Rigidbody>();
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			rigidbody.Sleep();
		}

        transform.position = new Vector3(transform.position.x + Horz, transform.position.y + Vert, transform.position.z);
        transform.rotation = Quaternion.Euler((startRot.x + RotVert), (startRot.y + RotHorz), startRot.z);

		if (Input.GetKeyDown (KeyCode.Space))
			CmdMakeSignal ();
    }

	[Command]
	void CmdMakeSignal()
	{
		GameObject signal = (GameObject)Instantiate (signalPrefab, transform.position, Quaternion.identity);

		signal.transform.parent = transform;

		NetworkServer.Spawn (signal);
	}

	public override void OnStartLocalPlayer()
	{
		Destroy (transform.GetChild (0).gameObject);
		GameObject model = Instantiate (ServerPlayer, transform.position, Quaternion.identity);
		model.transform.parent = transform;
	}
}
