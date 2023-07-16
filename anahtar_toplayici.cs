using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anahtar_toplayici : MonoBehaviour
{
    public GameObject player;
    public GameObject yonerg02;
    public GameObject yonerge05;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(Vector3.Distance(player.transform.position,transform.position)<30f)
        {
            yonerg02.SetActive(true);

            if(Input.GetKeyDown(KeyCode.T))
            {
                GetComponent<key_destroy>().destroy = true;
                yonerg02.SetActive(false);
            }

        }


        if(Vector3.Distance(player.transform.position, transform.position)>30f && Vector3.Distance(player.transform.position, transform.position)<50f)
        {
            yonerg02.SetActive(false);
        }


    }
}
