using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alev_topu_spawner : MonoBehaviour
{
    public bool aktif;
    private float sayac;
    public GameObject alev_topu;
    public Transform[] top_yeri;
    public int i = 0;
    void Update()
    {

        if (aktif)
        {
            sayac += Time.deltaTime;
        }


        if (sayac > 20f)
        {
            if (i == 5)
            {
                i = 0;
            }

            Instantiate(alev_topu, top_yeri[i].position, Quaternion.identity);
            sayac = 0f;
            i++;
        }


    }
}
