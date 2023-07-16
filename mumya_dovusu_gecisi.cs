using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mumya_dovusu_gecisi : MonoBehaviour
{
    public float mesafe;
    public GameObject yonerge02;
    public Transform player;
    void Update()
    {

        mesafe = Vector3.Distance(transform.position, player.position);

        if (mesafe <= 30f)
        {
            yonerge02.SetActive(true);

            if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene("Mumya_dovus");
            }

        }

        else
        {
            yonerge02.SetActive(false);
        }

    }

}
