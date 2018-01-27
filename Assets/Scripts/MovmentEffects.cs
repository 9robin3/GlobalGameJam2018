using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentEffects : MonoBehaviour {

    [SerializeField]
    float moveStrenght;
    [SerializeField]
    float smoothStrength;

    GameObject background;
    Vector3 fejkPos;
    Vector3 BGStartPos;

    private void Start()
    {
        background = transform.GetChild(0).gameObject;
        BGStartPos = background.transform.position;
    }

    private void Update()
    {
        float Vert = Input.GetAxis("Vertical") * moveStrenght;
        float Horz = Input.GetAxis("Horizontal") * moveStrenght;
        float step = smoothStrength * Time.deltaTime;

        fejkPos = new Vector3(BGStartPos.x + Horz, BGStartPos.y + Vert);
        background.transform.position = Vector3.MoveTowards(background.transform.position, fejkPos, step);

    }
}
