using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaya_spawner : MonoBehaviour
{
    public bool gonder=false;
    public GameObject gaya;
    private float sure1=0f;
    private float sure2=1f;
    public bool sag=true;

    void FixedUpdate()
    {
        
        if (sag)
        {
            if (gonder)
            {
                sure1 += Time.deltaTime;
                if (sure1>6f && sure1<6.5f)
                {
                    Instantiate(gaya, transform.position, Quaternion.identity);
                    sure1 = 0f;
                }
            }
        }



        else
        {
            if (gonder)
            {
                sure2 += Time.deltaTime;
                if (sure2>8f && sure2<8.5f)
                {
                    Instantiate(gaya, transform.position, Quaternion.identity);
                    sure2 = 2f;
                }
            }
        }


    }
}
