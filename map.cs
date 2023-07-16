using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    public GameObject m,m_i;
    private bool m_a = false, m_b = true,sayac=false;
    private float zaman=0f;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) && m_b)
        {
            if(m_a)
            {
                m_a = false;
            }

            else
            {
                m_a = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.M) && m_b==false)
        {
            sayac = true;
        }


        if(m_a)
        {
            m.SetActive(true);
        }

        else
        {
            m.SetActive(false);
        }


        if(GetComponent<Player_movements>().anahtar_sayac>=5)
        {
            m_b = false;
            m_a = false;
        }


        if(sayac)
        {
            m_i.SetActive(true);
            zaman += Time.deltaTime;
            if(zaman>4f)
            {
                sayac = false;
                zaman = 0f;
                m_i.SetActive(false);
            }
        }

        
    }
}
