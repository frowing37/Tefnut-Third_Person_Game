using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ankha : MonoBehaviour
{
    public float dikey_h�z;
    public float yatay_h�z;
    Vector3 d_velocity;
    Vector3 y_velocity;
    public float yon = 1f;

    void FixedUpdate()
    {
        y_velocity = yatay_h�z * new Vector3(0f, 0f, 1f) * Time.deltaTime;
        transform.Rotate(y_velocity);
        

        d_velocity = dikey_h�z * new Vector3(0f, 0f, 1f) * Time.deltaTime * yon;
        if(transform.position.y<=40f)
        {
            yon = 1f;
        }

        if(transform.position.y>=50.3)
        {
            yon = -1f;
        }
        transform.Translate(d_velocity);

    }
}
