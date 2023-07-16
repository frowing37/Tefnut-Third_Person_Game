using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lav_havuzu : MonoBehaviour
{
    public GameObject player;
    public Transform lav_checker;
    private bool yaniyom;
    public LayerMask Player_layer;
    private void Update()
    {
        yaniyom = Physics.CheckBox(lav_checker.position,new Vector3(500f,1f,500f) ,Quaternion.identity, Player_layer);
        
        if(yaniyom)
        {
            player.GetComponent<Player_movements>().lav_hasar = true;
        }

        else
        {
            player.GetComponent<Player_movements>().lav_hasar = false;
        }

    }

}
