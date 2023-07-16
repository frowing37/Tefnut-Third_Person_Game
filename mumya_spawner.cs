using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mumya_spawner : MonoBehaviour
{

    public GameObject mumya;
    private float sayac=0f;
    public bool aktif=false;
    public bool bolum_sonu=false;
    public bool ilk_aktif = false;
    public int dalga_sayisi=0;
    private float deadline = 10f;
    public GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
        if(ilk_aktif)
        {
            Instantiate(mumya, transform.position, Quaternion.identity);
            ilk_aktif = false;
        }


        if(aktif)
        {
            sayac += Time.deltaTime; 
        }
        

        if(sayac>=deadline)
        {
            Instantiate(mumya, transform.position, Quaternion.identity);
            dalga_sayisi++;
            sayac = 0f;
        }


        if(dalga_sayisi>8)
        {
            deadline = 6f;
            //player.GetComponent<Player_movements>().m_hasar = 15f;
        }

        if(dalga_sayisi>=20)
        {
            aktif = false;
            bolum_sonu = true;
        }

        if(bolum_sonu)
        {

        }

    }
}
