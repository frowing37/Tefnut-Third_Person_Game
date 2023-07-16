using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaya_hasar : MonoBehaviour
{
    
    public bool kaya;
    public LayerMask player_layer;

    private void Update()
    {
        kaya = Physics.CheckSphere(transform.position, 9.8f, player_layer);
        
        if(kaya)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_movements>().kaya_hasar=true;
        }
    }

   
}

