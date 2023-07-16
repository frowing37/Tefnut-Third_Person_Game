using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class e_Skill : MonoBehaviour
{
    public GameObject player;
    public Slider e;
    public float e_time;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        e_time = player.GetComponent<Animation_Controller>().e_sayac;
        e.value = e_time;
    }
}
