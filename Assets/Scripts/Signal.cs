using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour {

	public AnimationCurve growth;

	public AnimationCurve fade;

	public float lifeTime;

	private float life;

	void Start () {
		life = 0;
	}

	// Update is called once per frame
	void Update () {

		float size = growth.Evaluate (life);
		transform.GetChild (0).localScale = new Vector3 (size,size,size);

		//transform.GetChild (0).GetComponent<MeshRenderer> ().material.color.a = fade.Evaluate (life);

		transform.rotation = Quaternion.identity;

		life += Time.deltaTime;

		if (life > lifeTime)
			Destroy (gameObject);
	}
}
