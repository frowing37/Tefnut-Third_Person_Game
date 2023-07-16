using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healt_bar : MonoBehaviour
{
    public GameObject player;
    public Slider can_barý;
    public float max_can;
    public float health;
    public GameObject cam;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("camera_ayarlari");
    }

    void Update()
    {
        health = player.GetComponent<Player_movements>().health;
        if(cam.GetComponent<Camera_controller>().death)
		{
            health = 0f;
		}
        can_barý.value = health;
    }
}
