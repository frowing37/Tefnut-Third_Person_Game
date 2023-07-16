using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anubis_mumyaları : MonoBehaviour
{
    private float sayac = 0f;
    public bool aktif = false;
    public GameObject mumya;
    private bool gonder=false;
    public bool ilk_aktif = false;
    private int dalga = 0;


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

        if (sayac >= 5f)
        {
            sayac = 0f;
            gonder = true;
            dalga++;
        }


        if (gonder)
        {
            Instantiate(mumya, transform.position, Quaternion.identity);
            gonder = false;
        }


        if(dalga==3)
        {
            aktif = false;
            dalga = 0;
        }


    }

}
