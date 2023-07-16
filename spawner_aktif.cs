using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_aktif : MonoBehaviour
{
    public GameObject[] spawner;
    public GameObject CT_S;
    public GameObject canvas;
    private bool sayac=false;
    private float zaman;

    private void Awake()
    {
        canvas.GetComponent<ilk_info>().ac();
    }


    private void OnTriggerEnter(Collider other)
    {
    
        if(other.CompareTag("Player"))
        {

            sayac = true;

            for(int i=0;i<4;i++)
            {
                spawner[i].GetComponent<mumya_spawner>().ilk_aktif = true;
                spawner[i].GetComponent<mumya_spawner>().aktif = true;
                CT_S.GetComponent<can_topu_spawn>().aktif = true;
            }
        }

    }

    private void FixedUpdate()
    {
        if(sayac)
        {
            zaman += Time.deltaTime;
            if(zaman>3f)
            {
                GetComponent<BoxCollider>().isTrigger = false;
            }
        }

    }

}
