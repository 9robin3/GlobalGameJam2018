using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour {

	public AnimationCurve growth;

	public AnimationCurve fade;

	public float lifeTime;

	private float life;

	private Color TexColor;

	void Start () {
		life = 0;

		TexColor = transform.GetChild (0).GetComponent<MeshRenderer> ().material.GetColor("_TintColor");
	}

	// Update is called once per frame
	void Update () {

		float size = growth.Evaluate (life);
		transform.GetChild (0).localScale = new Vector3 (size,size,size);

		transform.GetChild (0).GetComponent<MeshRenderer> ().material.SetColor("_TintColor", new Color(TexColor.r,TexColor.g,TexColor.b,fade.Evaluate(life)));

		transform.rotation = Quaternion.identity;

		life += Time.deltaTime;

		if (life > lifeTime)
			Destroy (gameObject);
	}
}
