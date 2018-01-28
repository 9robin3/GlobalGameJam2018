using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenEffect : MonoBehaviour {

    [SerializeField]
    AnimationCurve curve;

    float timer;
    float endTime;
    Vector3 startScale;
    Vector3 starPos;

    private void Start()
    {
        endTime = 1.5f;//curve.length;
        startScale = transform.localScale;
        starPos = transform.position;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= endTime)
            timer = 0;

        float curveValue = curve.Evaluate(timer);

        gameObject.transform.localScale = new Vector3(
            startScale.x * curveValue,
            startScale.y * curveValue,
            startScale.z * curveValue);

        transform.position = new Vector3(
            starPos.x * (curveValue * 0.3f),
            starPos.y * (curveValue * 0.3f),
            starPos.z * (curveValue * 0.3f)
            );
    }
}