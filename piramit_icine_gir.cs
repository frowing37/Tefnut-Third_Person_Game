using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class piramit_icine_gir : MonoBehaviour
{
    public float mesafe;
    public GameObject yonerge01;
    public GameObject yonerge03;
    public GameObject player;
    private bool sayac = false;
    private float zaman;
    public GameObject canvas;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {

        mesafe = Vector3.Distance(transform.position, player.transform.position);

        if (mesafe < 40f && mesafe > 0.01f)
        {
            yonerge01.SetActive(true);

            if (Input.GetKeyDown(KeyCode.T) && player.GetComponent<Player_movements>().anahtar_sayac == 8)
            {
                //canvas.GetComponent<ilk_info>().ac();
                SceneManager.LoadScene("Piramit_ici");
            }

            else if (Input.GetKeyDown(KeyCode.T) && player.GetComponent<Player_movements>().anahtar_sayac < 8)
            {
                yonerge03.SetActive(true);
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
                yonerge03.SetActive(false);
            }
        }


    }

}
