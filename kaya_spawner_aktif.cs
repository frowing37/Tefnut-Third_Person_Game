using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaya_spawner_aktif : MonoBehaviour
{
    public GameObject spawner;
    public GameObject spawner2;
    public GameObject canvas;

    private void Awake()
    {
        canvas.GetComponent<ilk_info>().ac();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            spawner.GetComponent<Kaya_spawner>().gonder = true;
            spawner2.GetComponent<Kaya_spawner>().gonder = true;
        }
    }

}
