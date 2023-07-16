using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class anahtar_sayaci_ui : MonoBehaviour
{
    public TextMeshProUGUI sayac;
    public GameObject player;
    private int anahtar_sayisi;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sayac = this.GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        anahtar_sayisi=player.GetComponent<Player_movements>().anahtar_sayac;
        if(anahtar_sayisi >= 7)
		{
            anahtar_sayisi = 7;
		}
        sayac.text = anahtar_sayisi.ToString();
    }
}
