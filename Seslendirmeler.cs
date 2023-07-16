using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seslendirmeler : MonoBehaviour
{
    public bool j_t;
    private AudioSource cachedAudioSource;
    public AudioClip anubis_giris_t;
    public AudioClip anubis_hasar1_t, anubis_hasar2_t, anubis_hasar3_t;
    public AudioClip anubis_olum_t;

    public AudioClip tefnut_mumyas�v��_t, tefnut_final_t, tefnut_agirhasar_t, tefnut_power_t;

    public GameObject player,anubis;
    public AudioClip anubis_giris;
    public AudioClip anubis_hasar1, anubis_hasar2, anubis_hasar3;
    public AudioClip anubis_olum;

    public AudioClip tefnut_mumyas�v��,tefnut_final,tefnut_agirhasar,tefnut_power;

    public int hasar_sira = 0;
    private float final_zaman = 0f;

    private void Start()
    {
        anubis_giris_t = Resources.Load<AudioClip>("Sounds/T�rk�e/anubis_giri�_t");
        anubis_hasar1_t= Resources.Load<AudioClip>("Sounds/T�rk�e/anubis_hasar1_t");
        anubis_hasar2_t= Resources.Load<AudioClip>("Sounds/T�rk�e/anubis_hasar2_t");
        anubis_hasar3_t= Resources.Load<AudioClip>("Sounds/T�rk�e/anubis_hasar3_t");
        anubis_olum_t= Resources.Load<AudioClip>("Sounds/T�rk�e/anubis_�l�m_t");
        tefnut_mumyas�v��_t= Resources.Load<AudioClip>("Sounds/T�rk�e/tefnut_mumyas�v��_t");
        tefnut_final_t= Resources.Load<AudioClip>("Sounds/T�rk�e/anubis_hasar1_t");
        tefnut_agirhasar_t= Resources.Load<AudioClip>("Sounds/T�rk�e/tefnut_hasar_t");
        tefnut_power_t= Resources.Load<AudioClip>("Sounds/T�rk�e/tefnut_iyile�me");

        anubis_giris = Resources.Load<AudioClip>("Sounds/Japonca/anubis_giri�");
        anubis_hasar1 = Resources.Load<AudioClip>("Sounds/Japonca/anubis_hasar1");
        anubis_hasar2 = Resources.Load<AudioClip>("Sounds/Japonca/anubis_hasar2");
        anubis_hasar3 = Resources.Load<AudioClip>("Sounds/Japonca/anubis_hasar3");
        anubis_olum = Resources.Load<AudioClip>("Sounds/Japonca/anubis_�l�m");
        tefnut_mumyas�v�� = Resources.Load<AudioClip>("Sounds/Japonca/tefnut_mumyas�v��");
        tefnut_final = Resources.Load<AudioClip>("Sounds/Japonca/tefnut_final");
        tefnut_agirhasar = Resources.Load<AudioClip>("Sounds/Japonca/tefnut_a��rhasar");
        tefnut_power = Resources.Load<AudioClip>("Sounds/Japonca/tefnut_g�� tamam");
    }


    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anubis= GameObject.FindGameObjectWithTag("anubis");
        cachedAudioSource = GetComponent<AudioSource>();
        j_t = true;
    }

    public void tefnut01()
    {
        if(j_t)
        {
            cachedAudioSource.PlayOneShot(anubis_giris);
        }

        else
        {
            cachedAudioSource.PlayOneShot(anubis_giris_t);
        }
    }

    public void tefnut02()
    {
        if(j_t)
        {
            cachedAudioSource.PlayOneShot(anubis_olum);
        }

        else
        {
            cachedAudioSource.PlayOneShot(anubis_olum_t);
        }
    }

    public void tefnut03()
    {
        final_zaman += Time.deltaTime;
        if(final_zaman>6f)
        {
            if(j_t)
            {
                cachedAudioSource.PlayOneShot(tefnut_final);
            }

            else
            {

            }
        }
    }

    public void tefnut04()
    {
        if(j_t)
        {
            cachedAudioSource.PlayOneShot(tefnut_power);
        }

        else
        {
            cachedAudioSource.PlayOneShot(tefnut_power_t);
        }
    }

    public void FixedUpdate()
    {
        if(anubis.GetComponent<anubis_ai>().anubis_health>0)
        {
            switch (hasar_sira)
            {
                case 1:
                    
                    if(j_t)
                    {
                        cachedAudioSource.PlayOneShot(anubis_hasar1);
                    }

                    else
                    {
                        cachedAudioSource.PlayOneShot(anubis_hasar1_t);
                    }
                    hasar_sira++;
                    break;
                case 3:
                    if(j_t)
                    {
                        cachedAudioSource.PlayOneShot(anubis_hasar2);
                    }

                    else
                    {
                        cachedAudioSource.PlayOneShot(anubis_hasar2_t);
                    }
                    hasar_sira++;
                    break;
                case 5:
                    if(j_t)
                    {
                        cachedAudioSource.PlayOneShot(anubis_hasar3);
                    }

                    else
                    {
                        cachedAudioSource.PlayOneShot(anubis_hasar3_t);
                    }
                    hasar_sira = 0;
                    break;
            }
        }


        if (player.GetComponent<Player_movements>().health < 20f && player.GetComponent<Player_movements>().just)
        {
            if(j_t)
            {
                cachedAudioSource.PlayOneShot(tefnut_agirhasar);
            }

            else
            {
                cachedAudioSource.PlayOneShot(tefnut_agirhasar_t);
            }
            player.GetComponent<Player_movements>().just = false;
        }

        else
        {

            if (player.GetComponent<Player_movements>().olen_mumyalar >= 20)
            {
                if(j_t)
                {
                    cachedAudioSource.PlayOneShot(tefnut_mumyas�v��);
                }

                else
                {
                    cachedAudioSource.PlayOneShot(tefnut_mumyas�v��_t);
                }
                player.GetComponent<Player_movements>().olen_mumyalar = 0;
            }
        }



    }



}
