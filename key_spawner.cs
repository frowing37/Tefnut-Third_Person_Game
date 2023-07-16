using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_spawner : MonoBehaviour
{
    public GameObject m_spawner;
    public GameObject key;
    public GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

        //Anahtarýn Ortaya Çýkmasý
        if(m_spawner.GetComponent<mumya_spawner>().dalga_sayisi==20)
        {
            Instantiate(key, transform.position,Quaternion.Euler(0f,0f,90f));
            GetComponent<anubise_gec>().enabled = true;
            m_spawner.GetComponent<mumya_spawner>().dalga_sayisi = 21;
        }

    }

}
