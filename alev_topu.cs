using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alev_topu : MonoBehaviour
{
    public float speed;
    public float y_speed;
    Vector3 dikey_velocity;
    Vector3 eksen_velocity;
    private float yon = 1f;
    public GameObject player;
    private float sayac;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<Player_movements>().q_time += 50;
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        //Kendi etraf�nda d�nmesi i�in
        eksen_velocity = speed * Time.deltaTime * new Vector3(0, 1, 0);
        transform.Rotate(eksen_velocity);


        //Yukar� a�a�� gitmesi i�in
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

        //Kendini �mha
        sayac += Time.deltaTime;
        if (sayac > 12f)
        {
            Destroy(this.gameObject);
        }

    }

}
