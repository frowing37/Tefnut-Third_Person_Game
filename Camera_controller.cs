using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    public GameObject cha;
    public float mouseSpeed;
    private float Xrot, Yrot;
    public float minx,maxx;
    private float x, z;
    Vector3 yon;
    public bool playable = false;
    public bool death = false;


    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0)
        {
            cha.transform.rotation = Quaternion.Lerp(transform.rotation, cha.transform.rotation, 0.3f);
        }
    }

    void LateUpdate()
    {
        if(playable)
        {
            //Kamera kontrolü
            Yrot += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSpeed;
            Xrot += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSpeed;
            Xrot = Mathf.Clamp(Xrot, minx, maxx);
            transform.GetChild(0).localRotation = Quaternion.Euler(Xrot, 0, 0);
            transform.localRotation = Quaternion.Euler(0, Yrot, 0);

            //Cursor
            UnityEngine.Cursor.visible = false;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        }

        else
        {
            //Cursor
            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
        }


    }

    private void FixedUpdate()
    {
        //Kameranýn karakteri takip etmesi
        transform.position = Vector3.Lerp(transform.position,cha.transform.position,0.3f);

    }

}
