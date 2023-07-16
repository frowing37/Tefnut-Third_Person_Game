using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class final_piramitine_gir : MonoBehaviour
{
    public float mesafe;
    public GameObject yonerge01;
    public GameObject yonerge04;
    public GameObject player;
    private bool sayac = false;
    private float zaman;
    public GameObject canvas;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas.GetComponent<ilk_info>().ac();
    }
    void Update()
    {

        mesafe = Vector3.Distance(transform.position, player.transform.position);

        if (mesafe <= 40f && mesafe >0.001f)
        {
            yonerge01.SetActive(true);

            if (Input.GetKeyDown(KeyCode.T) && player.GetComponent<Player_movements>().final_anahtar==1)
            {
                SceneManager.LoadScene("anubis_fight");
            }

            else if (Input.GetKeyDown(KeyCode.T) && player.GetComponent<Player_movements>().final_anahtar != 1)
            {
                yonerge04.SetActive(true);
                sayac = true;
            }

        }

        else
        {
            yonerge01.SetActive(false);
        }



        if (sayac)
        {
            zaman += Time.deltaTime;
            if (zaman > 5f)
            {
                sayac = false;
                zaman = 0f;
                yonerge04.SetActive(false);
            }
        }


    }

}
