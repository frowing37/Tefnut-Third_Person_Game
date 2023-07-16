using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seslendirmeler2 : MonoBehaviour
{
    public bool j_t = true;

    public AudioClip tefnut_mumyasövüþ_t, tefnut_agirhasar_t, tefnut_power_t;
    public AudioClip tefnut_mumyasövüþ, tefnut_agirhasar, tefnut_power;
    public GameObject player;
    private int tercih;


    public int hasar_sira = 0;

    private void Start()
    {
        if(PlayerPrefs.HasKey("DilTercih"))
        {
            tercih = PlayerPrefs.GetInt("DilTercih");
        }
    }

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        j_t = true;
    }


    public void tefnut04()
    {
        if (j_t)
        {
            GetComponent<AudioSource>().PlayOneShot(tefnut_power);
        }

        else
        {
            GetComponent<AudioSource>().PlayOneShot(tefnut_power_t);
        }
    }


    public void FixedUpdate()
    {

        if (player.GetComponent<Player_movements>().health < 20f && player.GetComponent<Player_movements>().just)
        {
            if (j_t)
            {
                GetComponent<AudioSource>().PlayOneShot(tefnut_agirhasar);
            }

            else
            {
                GetComponent<AudioSource>().PlayOneShot(tefnut_agirhasar_t);
            }
            player.GetComponent<Player_movements>().just = false;
        }

        else
        {

            if (player.GetComponent<Player_movements>().olen_mumyalar >= 20)
            {
                if (j_t)
                {
                    GetComponent<AudioSource>().PlayOneShot(tefnut_mumyasövüþ);
                }

                else
                {
                    GetComponent<AudioSource>().PlayOneShot(tefnut_mumyasövüþ_t);
                }
                player.GetComponent<Player_movements>().olen_mumyalar = 0;
            }
        }



    }


}
