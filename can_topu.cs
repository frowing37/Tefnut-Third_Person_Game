using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can_topu : MonoBehaviour
{
    public float speed;
    public float y_speed;
    Vector3 dikey_velocity;
    Vector3 eksen_velocity;
    private float yon = 1f;
    public GameObject player,music;
    private float sayac;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        music = GameObject.FindGameObjectWithTag("music");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<Player_movements>().health = 100f;
            player.GetComponent<Player_movements>().just = true;
            if(player.GetComponent<Player_movements>().final)
            {
                music.GetComponent<Seslendirmeler>().tefnut04();
            }

            else
            {
                music.GetComponent<seslendirmeler2>().tefnut04();
            }
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        //Kendi etrafýnda dönmesi için
        eksen_velocity = speed * Time.deltaTime * new Vector3(0, 1, 0);
        transform.Rotate(eksen_velocity);


        //Yukarý aþaðý gitmesi için
        if (transform.position.y < 6.7f)
        {
            yon = 1f;
        }

        else if (transform.position.y > 17f)
        {
            yon = -1f;
        }

        dikey_velocity = transform.up * yon * Time.deltaTime * y_speed;
        transform.Translate(dikey_velocity);

        //Kendini Ýmha
        sayac += Time.deltaTime;
        if (sayac > 12f)
        {
            Destroy(this.gameObject);
        }

    }

}
