using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LASER1 : MonoBehaviour
{
    public GameObject laser_hedef;
    public GameObject player;
    RaycastHit hit;
    public LayerMask Obstacle;
    public LayerMask Player_layer;
    public bool yatay_aktif = false;
    public bool yatay2_aktif = false;
    Vector3 velocity = new Vector3(1f, 0f, 0f);
    public float speed = 100f;
    private int tur = 0;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {

        if (Physics.Raycast(transform.position, transform.forward, out hit, Vector3.Distance(transform.position, laser_hedef.transform.position), Obstacle))
        {
            GetComponent<LineRenderer>().enabled = true;
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);
        }



        if (Physics.Raycast(transform.position, transform.forward, out hit, Vector3.Distance(transform.position, laser_hedef.transform.position), Player_layer))
        {
            player.GetComponent<Player_movements>().laser_hasar = true;
        }

        else
        {
            player.GetComponent<Player_movements>().laser_hasar = false;
        }


        if (yatay_aktif)
        {

            if (transform.position.x <= -262.8f)
            {
                speed *= -1;
                tur += 1;
            }

            if (transform.position.x >= 5.1f)
            {
                speed *= -1;
                tur += 1;
            }

            if (tur == 6)
            {
                tur = 0;
                yatay_aktif = false;
            }

            transform.Translate(velocity * Time.deltaTime * speed);
            laser_hedef.transform.Translate(velocity * Time.deltaTime * speed);
        }

        if (yatay2_aktif)
        {

            if (transform.position.x <= -262.8f)
            {
                speed *= -1;
                tur += 1;
            }

            if (transform.position.x >= 5.1f)
            {
                speed *= -1;
                tur += 1;
            }

            if (tur == 6)
            {
                tur = 0;
                yatay2_aktif = false;
            }

            transform.Translate(velocity * Time.deltaTime * -speed);
            laser_hedef.transform.Translate(velocity * Time.deltaTime * -speed);

        }




    }
}
