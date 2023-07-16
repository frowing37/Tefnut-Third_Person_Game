using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyu_spawn : MonoBehaviour
{
    public float sayac=0;
    public bool aktif = false;
    public GameObject buyu;
    public Transform buyu_noktasi;
    void Update()
    {
      
        if(aktif)
        {
            sayac += Time.deltaTime;
        }


        if(sayac>1.12)
        {
            Instantiate(buyu, buyu_noktasi.position, Quaternion.identity);
            aktif = false;
            sayac = 0f;
        }


    }

}
