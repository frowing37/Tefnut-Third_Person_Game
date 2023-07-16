using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iyilesme : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.GetComponent<Player_movements>().health = 100f;
        }
    }
}
