using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yatay_tuzak : MonoBehaviour
{
    public bool yon=true;
    public float speed;
    public GameObject player;
    void FixedUpdate()
    {
        if (yon)
        {
            transform.Rotate(new Vector3(0, 1, 0) * speed);
        }

        else
        {
            transform.Rotate(new Vector3(0, 1, 0) * speed * -1);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.GetComponent<Player_movements>().hasar = true;
        }
    }


}
