using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_collison : MonoBehaviour
{

    public Transform cam;
    public float smooth=8f;
    private float distance;
    public float max_distance=39f;
    public float min_distance=18f;
    Vector3 normalize_position;
    RaycastHit hit;


    void Start()
    {
        normalize_position = cam.transform.localPosition.normalized;
        distance = cam.transform.localPosition.magnitude;
    }


    void Update()
    {
        Vector3 camera_position = cam.transform.parent.TransformPoint(normalize_position * max_distance);

        if (Physics.Linecast(cam.transform.parent.position, camera_position, out hit))
        {
            distance = Mathf.Clamp(hit.distance, min_distance, max_distance);
        }

        else
        {
            distance = max_distance;
        }


        cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, normalize_position*distance, smooth * Time.deltaTime);


    }
}
