using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme1 : MonoBehaviour
{
    public bool temas;
    public LayerMask obstacle;
    Vector3 velocity;
    public float speed;
    public bool baslat;

       void Update()
    {
        temas = Physics.CheckSphere(transform.position,5f,obstacle,QueryTriggerInteraction.UseGlobal);

        if (baslat)
        {

            if (temas)
            {
                GetComponent<Rigidbody>().useGravity = true;
            }


            else
            {
                GetComponent<Rigidbody>().useGravity = false;
            }

        }

       
    }


}
