using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    Vector3 eksen_velocity;
    public float speed;
    void FixedUpdate()
    {


        //Kendi etraf�nda d�nmesi i�in
        eksen_velocity = speed * Time.deltaTime * new Vector3(1, 0, 0);
        transform.Rotate(eksen_velocity);


    }

}
