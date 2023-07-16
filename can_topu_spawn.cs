using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can_topu_spawn : MonoBehaviour
{
    public bool aktif;
    private float sayac;
    public GameObject can_topu;
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
            if (i == 4)
            {
                i = 0;
            }

            Instantiate(can_topu, top_yeri[i].position, Quaternion.identity);
            sayac = 0f;
            i++;
        }


    }

}
