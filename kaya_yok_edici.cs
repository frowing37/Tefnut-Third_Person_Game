using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaya_yok_edici : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kaya"))
        {
            Destroy(other.gameObject);
        }
    }
}
