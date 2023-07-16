using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kanama_sil : MonoBehaviour
{
    private float sayac=0;
   void Update()
    {

        sayac += Time.deltaTime;

        if(sayac>=2.5f)
        {
            Destroy(this.gameObject);
        }

    }
}
