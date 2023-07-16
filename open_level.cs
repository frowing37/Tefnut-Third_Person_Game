using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_level : MonoBehaviour
{
    public GameObject anubis;
    public GameObject top_spawner;
    public GameObject seslendirmeler;
    private float zaman = 0f;
    private bool sayac = false;
    public GameObject canvas;


    private void Awake()
    {
        canvas.GetComponent<ilk_info>().ac();
    }


    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player"))
        {
            anubis.GetComponent<anubis_ai>().DON = true;
            top_spawner.GetComponent<can_topu_spawn>().aktif = true;
            top_spawner.GetComponent<alev_topu_spawner>().aktif = true;
            seslendirmeler.GetComponent<Seslendirmeler>().tefnut01();
            sayac = true;
        }
    }

    private void Update()
    {
        if(sayac)
        {
            zaman += Time.deltaTime;
            if(zaman>3f)
            {
                GetComponent<BoxCollider>().isTrigger = false;
                sayac = false;
            }
        }
    }


}
