using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject[] laser_hedef;
    public GameObject[] laser_kaynak;
    public GameObject player;
    RaycastHit hit;
    public LayerMask Obstacle;
    public LayerMask Player_layer;
    public float sayac = 0f, speed = 50f;
    public bool aktif_mek = false;
    private float yon1=1f,yon2=1f, yon3 = 1f, yon4 = 1f;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void laser_hasar()
    {
        player.GetComponent<Player_movements>().health -= 7;
        player.GetComponent<Player_movements>().kan = true;
    }

    void FixedUpdate()
    {
       for(int i=0;i<4;i++)
        {

            if (Physics.Raycast(laser_kaynak[i].transform.position, laser_kaynak[i].transform.forward, out hit, Vector3.Distance(laser_kaynak[i].transform.position, laser_hedef[i].transform.position), Obstacle))
            {
                laser_kaynak[i].GetComponent<LineRenderer>().enabled = true;
                laser_kaynak[i].GetComponent<LineRenderer>().SetPosition(0, laser_kaynak[i].transform.position);
                laser_kaynak[i].GetComponent<LineRenderer>().SetPosition(1, hit.point);
            }



            if (Physics.Raycast(laser_kaynak[i].transform.position, laser_kaynak[i].transform.forward, out hit, Vector3.Distance(laser_kaynak[i].transform.position, laser_hedef[i].transform.position), Player_layer))
            {
                laser_hasar();
            }


            if(aktif_mek)
            {
                sayac += Time.fixedDeltaTime;

                if(i==0)
                {
                    if (laser_kaynak[i].transform.position.x >= -140f)
                    {
                        yon1 = -1;
                    }

                    if (laser_kaynak[i].transform.position.x <= -260f)
                    {
                        yon1 = 1;
                    }

                    Vector3 velocity1 = new Vector3(1f, 0f, 0f) * Time.deltaTime * speed * yon1;
                    laser_kaynak[i].transform.Translate(velocity1);
                    laser_hedef[i].transform.Translate(velocity1);
                }

                if(i==1)
                {
                    if(laser_kaynak[i].transform.position.x < -120f)
                    {
                        yon2 = 1f;
                    }

                    if(laser_kaynak[i].transform.position.x > 0f)
                    {
                        yon2 = -1f;
                    }

                    Vector3 velocity2 = new Vector3(1f, 0f, 0f) * Time.deltaTime * speed * yon2;
                    laser_kaynak[i].transform.Translate(velocity2);
                    laser_hedef[i].transform.Translate(velocity2);

                }

                if(i==2)
                {
                    if (laser_kaynak[i].transform.position.z < -126f)
                    {
                        yon3 = -1f;
                    }

                    if (laser_kaynak[i].transform.position.z > -6f)
                    {
                        yon3 = 1f;
                    }

                    Vector3 velocity3 = new Vector3(1f, 0f, 0f) * Time.deltaTime * speed * yon3;
                    laser_kaynak[i].transform.Translate(velocity3);
                    laser_hedef[i].transform.Translate(velocity3);
                }


                if(i==3)
                {
                    if (laser_kaynak[i].transform.position.z < 16f)
                    {
                        yon4 = -1f;
                    }

                    if (laser_kaynak[i].transform.position.z > 136f)
                    {
                        yon4 = 1f;
                    }

                    Vector3 velocity4 = new Vector3(1f, 0f, 0f) * Time.deltaTime * speed * yon4;
                    laser_kaynak[i].transform.Translate(velocity4);
                    laser_hedef[i].transform.Translate(velocity4);
                }


                if(sayac>40f)
                {
                    aktif_mek = false;
                    sayac = 0f;
                }
            }




        }



    }
}
