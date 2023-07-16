using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anubis_buyu : MonoBehaviour
{
    public GameObject player;
    public GameObject hedef;
    private float speed=75f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        hedef = GameObject.FindGameObjectWithTag("hedef");
    }

    void FixedUpdate()
    {
        //Büyü vektörü
        transform.Translate(transform.forward*Time.deltaTime*speed);
        transform.LookAt(hedef.transform);
       
        if(Vector3.Distance(transform.position, hedef.transform.position)<=1f)
        {
            player.GetComponent<Player_movements>().anubis_buyu_hasar = true;
            Destroy(this.gameObject);
        }
    }


}
