using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGulle_s : MonoBehaviour
{
    public GameObject anubis;
    public GameObject h_anubis;
    private float speed = 200f;
    Vector3 forward=new Vector3(0f, 0f, 1f);

    private void Awake()
    {
        anubis = GameObject.FindGameObjectWithTag("anubis");
        h_anubis = GameObject.FindGameObjectWithTag("h_anubis");
    }

    void LateUpdate()
    {
        //Büyü Vektörü
        speed -= Time.deltaTime * 25f;
        transform.LookAt(h_anubis.transform);
        transform.Translate(forward * Time.deltaTime * speed);

        //Büyü Anubis'e Deydiðinde
        float length = Vector3.Distance(transform.position, h_anubis.transform.position);
        Debug.Log(length);

        if(length < 7f)
        {
            anubis.GetComponent<anubis_ai>().anubis_hasar();
            Destroy(this.gameObject);
        }
    }
}
