using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    public class MovmentEffects : MonoBehaviour
    {

        [SerializeField]
        float moveStrenght;
        [SerializeField]
        float smoothStrength;
        [SerializeField]
        float moveBlurStrength;

        [SerializeField]
        float fishEyeStrength;
        [SerializeField]
        AnimationCurve curve;
        [SerializeField]
        float curveTime;
        [SerializeField]
        float fishEyeStrenghtMultiplier;

        GameObject background;
        Vector3 fejkPos;
        Vector3 BGStartPos;

        BloomAndFlares bloom;
        float bloomStart;

        Fisheye fish;
        Vector2 fishEyeStart;
        float timer;

        private void Awake()
        {
            background = transform.GetChild(0).gameObject;
            BGStartPos = background.transform.localPosition;

            print(background.transform.localPosition);

            bloom = GetComponent<BloomAndFlares>();
            bloomStart = bloom.sepBlurSpread;

            fish = GetComponent<Fisheye>();
            fishEyeStart.x = fish.strengthX;
            fishEyeStart.y = fish.strengthY;
        }


        private void Update()
        {
            backgroundMovment();
            blureffect();
            fishEye();
        }

        private void fishEye()
        {
            if (timer <= curveTime)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                timer = 0;
            }

            float Vert = ((Mathf.Abs(Input.GetAxis("Vertical")) * fishEyeStrength) + 1);
            float Horz = ((Mathf.Abs(Input.GetAxis("Horizontal")) * fishEyeStrength) + 1);

            if (Vert > Horz) { 
                fish.strengthX = ((curve.Evaluate(timer) * fishEyeStrenghtMultiplier) * Vert);
                fish.strengthY = ((curve.Evaluate(timer) * fishEyeStrenghtMultiplier) * Vert);
            } else {
                fish.strengthX = ((curve.Evaluate(timer) * fishEyeStrenghtMultiplier) * Vert);
                fish.strengthY = ((curve.Evaluate(timer) * fishEyeStrenghtMultiplier) * Vert);
            }
        }

        private void blureffect()
        {
            float Vert = ((Mathf.Abs(Input.GetAxis("Vertical")) * moveBlurStrength) + 1);
            float Horz = ((Mathf.Abs(Input.GetAxis("Horizontal")) * moveBlurStrength) + 1);

            if(Vert > Horz)
                bloom.sepBlurSpread = (bloomStart * Vert);
            else
                bloom.sepBlurSpread = (bloomStart * Horz);
        }

        private void backgroundMovment()
        {
            float Vert = Input.GetAxis("Vertical") * moveStrenght;
            float Horz = Input.GetAxis("Horizontal") * moveStrenght;
            float step = smoothStrength * Time.deltaTime;

            fejkPos = new Vector3(BGStartPos.x + Horz, BGStartPos.y + Vert, BGStartPos.z);
            background.transform.localPosition = Vector3.MoveTowards(background.transform.localPosition, fejkPos, step);
        }
    }
}