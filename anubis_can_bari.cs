using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anubis_can_bari : MonoBehaviour
{

    public GameObject anubis;
    public Slider can_bar�;
    public float max_can;
    public float health;


    private void Awake()
    {
        anubis = GameObject.FindGameObjectWithTag("anubis");
    }

    void Update()
    {
        health = anubis.GetComponent<anubis_ai>().anubis_health;
        can_bar�.value = health;
    }


}
