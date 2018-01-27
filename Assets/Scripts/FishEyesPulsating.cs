using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects {

    public class FishEyesPulsating : MonoBehaviour {

        [SerializeField]
        AnimationCurve curve;
        [SerializeField]
        float curveTime;
        [SerializeField]
        float fishEyeStrenghtMultiplier;

        Fisheye fisheyeComponent;
        float timer;

        private void Start()
        {
            fisheyeComponent = GetComponent<Fisheye>();
        }

        private void Update()
        {
            if (timer <= curveTime)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                timer = 0;
            }

            fisheyeComponent.strengthX = (curve.Evaluate(timer) * fishEyeStrenghtMultiplier);
            fisheyeComponent.strengthY = (curve.Evaluate(timer) * fishEyeStrenghtMultiplier);
        }

    }
}