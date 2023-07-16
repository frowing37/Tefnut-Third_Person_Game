using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaya_spawner_deaktif : MonoBehaviour
{

    public GameObject spawner;
    public GameObject spawner2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spawner.GetComponent<Kaya_spawner>().gonder = false;
            spawner2.GetComponent<Kaya_spawner>().gonder = false;
        }
    }

}
