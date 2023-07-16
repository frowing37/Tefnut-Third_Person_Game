using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anubise_gec : MonoBehaviour
{
    public float mesafe;
    public GameObject yonerge03;
    public GameObject player;
    public GameObject key;
    public GameObject mumya_spawner;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {

        mesafe = Vector3.Distance(key.transform.position, player.transform.position);

        if (mesafe <= 20f && mumya_spawner.GetComponent<mumya_spawner>().dalga_sayisi>=20)
        {
            yonerge03.SetActive(true);

            if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene("col");
            }

        }

        else
        {
            yonerge03.SetActive(false);
        }

    }

}
