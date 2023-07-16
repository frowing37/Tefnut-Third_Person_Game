using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class q_skill : MonoBehaviour
{
    public GameObject player;
    public Slider q;
    public float q_time;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        q_time = player.GetComponent<Player_movements>().q_time;
        q.value = q_time;
    }
}
