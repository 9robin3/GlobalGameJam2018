using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public static Parallax self;

    private List<Transform> backgrounds;
    private List<float> parallaxScales;
    [Space]
    [Space]
    [Space]
    [SerializeField]
    private float smoothing = 1f;

    private Transform cam;
    private Vector3 previousCamPos;

    void Awake()
    {
        self = this;
        backgrounds = new List<Transform>();
        parallaxScales = new List<float>();
        cam = Camera.main.transform;
    }

    public void i_addToList(Transform trans, float parallax)
    {
        backgrounds.Add(trans);
        parallaxScales.Add((trans.position.z + parallax)* -1);
    }

    private void Start()
    {
        previousCamPos = cam.position;
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Count; i++)
        {
            //the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            //set a target x position that is the current position plus the parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            //create a target position which is the backgrounds current position with it's target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //fade batween current position and the target position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

        }
        previousCamPos = cam.position;
    }
}