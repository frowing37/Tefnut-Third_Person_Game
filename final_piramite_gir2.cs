using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class final_piramite_gir2 : MonoBehaviour
{
    public float mesafe;
    public GameObject yonerge01;
    public GameObject player;
    public GameObject canvas;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas.GetComponent<ilk_info>().ac();
    }
    void Update()
    {

        mesafe = Vector3.Distance(transform.position, player.transform.position);

        if (mesafe <= 40f && mesafe > 0.001f)
        {
            yonerge01.SetActive(true);

            if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene("anubis_fight");
            }

        }

        else
        {
            yonerge01.SetActive(false);
        }


    }
}
