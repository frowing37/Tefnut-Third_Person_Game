using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_destroy : MonoBehaviour
{
    public bool destroy=false;
    public GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {

        if(destroy)
        {
            player.GetComponent<Player_movements>().anahtar_sayac++;
            Destroy(this.gameObject);
        }

        

    }
}
