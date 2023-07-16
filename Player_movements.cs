using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_movements : MonoBehaviour
{
    Vector3 moveVelocity;
    Vector3 moveInputs;
    public float speed=30f;
    private CharacterController controller;

    float position_y,position_x,position_z;
    
    private bool Is_ground;
    public Transform groundchecker;
    private float checkerradius;
    public LayerMask obstacleLayer;
    Vector3 velocity;
    private float gravity = -9f;
    private int select_speed;
    public GameObject player;
    public float health=100f;
    public float m_hasar=8.9f;

    public GameObject kan_efekti;
    public bool kan = false;
    public Transform kan_point;
    public bool hasar=false;
    public bool lav_hasar = false;
    public bool kaya_hasar=false;
    public bool mumya_hasar=false;
    public bool laser_hasar = false;
    public bool anubis_buyu_hasar = false;
    public bool just = true;

    public Transform dyak;
    public bool dyak_alan;
    public LayerMask mumya_mask;
    public int olen_mumyalar=0;

    public int anahtar_sayac=0;

    public GameObject playerGulle;
    public Transform gullePoint;
    private bool gulle_sayac_b = false;
    private float gulle_sayac = 0f;
    public float q_time = 100f;
    public int final_anahtar=0;

    public float yonerge_zaman = 0;
    public bool yonerge_sayac = false;
    public GameObject yonerge05;

    public bool playable0 = false;
    public bool playable1 = false;
    public GameObject kaybetme_menu;
    public GameObject mumya_spawner;
    public GameObject camera_ayarlari;
    public bool final;



    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        mumya_spawner = GameObject.FindGameObjectWithTag("mumya_spawner");
        camera_ayarlari= GameObject.FindGameObjectWithTag("camera_ayarlari");
    }

    private void Start()
    {
        health = 100f;

        if(PlayerPrefs.HasKey("key"))
        {
            final_anahtar = PlayerPrefs.GetInt("key");
        }

        else
        {
            final_anahtar = 0;
        }

    }

    public void final_anahta()
    {
        final_anahtar++;
        PlayerPrefs.SetInt("key", final_anahtar);
    }

    public bool sahne_kontrol(Scene scene)
    {
        if(scene.name=="anubis_fight")
        {
            return true;
        }

        return false;
    }

    public void anahtar_tamam()
    {

    }


    private void FixedUpdate()
    {
        //Baþlangýç Konum Verisini Kaydeder
        PlayerPrefs.SetFloat("konum_y",150f);
        PlayerPrefs.SetFloat("konum_x", 485f);
        PlayerPrefs.SetFloat("konum_z", 1150f);
        position_x = PlayerPrefs.GetFloat("konum_x");
        position_y = PlayerPrefs.GetFloat("konum_y");
        position_z = PlayerPrefs.GetFloat("konum_z");
        transform.position = new Vector3(position_x, position_y, position_z);


       if(playable0)
        {
            //Hareket
            moveInputs = Input.GetAxis("Horizontal") * -1 * transform.right + Input.GetAxis("Vertical") * -1 * transform.forward;

            moveVelocity = (moveInputs * speed * Time.deltaTime);

            controller.Move(moveVelocity);
        }

        
            
            if (Input.GetMouseButton(1) && Is_ground)
            {
                select_speed=3;
            }

            else
            {
                select_speed = 1;
            }
        
    
        switch(select_speed)
        {
            case 1:
                speed = 30f;
                break;


            case 3:
                speed = 55f;
                break;

            case 4:
                speed = 22f;
                break;
        }


        //Zýplama Vektörü
        controller.Move(2*velocity * Time.deltaTime);



        //Tuzak Hasarý
        if(hasar)
        {
            health -= 25f;
            hasar = false;
            kan = true;
        }


        //Lav Hasarý
        if(lav_hasar)
        {
            health -= Time.deltaTime * 30f;
        }

        //Kaya Hasarý
        if(kaya_hasar)
        {
            health -= 20f;
            kaya_hasar = false;
            kan = true;
        }

        //Mumya Hasarý
        if(mumya_hasar)
        {
            if(final)
            {
                m_hasar = 5f;
            }

            else
            {
                m_hasar = mumya_spawner.GetComponent<mumya_spawner>().dalga_sayisi * 1.8f;
            }

            health -= m_hasar;
            mumya_hasar = false;
            kan = true;
        }

        //Kanama efekti
        if(kan)
        {
            Instantiate(kan_efekti, kan_point.position, Quaternion.Euler(0f,0f,90f));
            kan = false;
        }

        //Laser Hasarý
        if(laser_hasar)
        {
            health -= 200f*Time.deltaTime;
            kan = true;
        }

        //Anubis Hasarý
        if(anubis_buyu_hasar)
        {
            health -= 25f;
            anubis_buyu_hasar = false;
            kan = true;
        }

        //Piramit Dýþý Anahtarlarý
        if (anahtar_sayac == 7)
        {
            anahtar_sayac++;
            yonerge_sayac = true;
            yonerge05.SetActive(true);
        }


        if (yonerge_sayac)
        {
            yonerge_zaman += Time.deltaTime;
            if (yonerge_zaman > 5f)
            {
                yonerge_sayac = false;
                yonerge_zaman = 0f;
                yonerge05.SetActive(false);
            }
        }


        if(health<=0f)
        {
            kaybetme_menu.SetActive(true);
            playable0 = false;
            playable1 = false;
            camera_ayarlari.GetComponent<Camera_controller>().death = true;
            camera_ayarlari.GetComponent<Camera_controller>().playable = false;
            Destroy(this.gameObject);
        }



    }


    private void LateUpdate()
    {
        //Zýplama ve Yer çekimi

        Is_ground = Physics.CheckSphere(groundchecker.position, 1f, obstacleLayer);

        if (!Is_ground)
        {
            velocity.y += gravity * Time.deltaTime * 3;
            select_speed = 4;
        }

        else
        {
            select_speed = 1;
        }


        if(Input.GetKeyDown(KeyCode.Space) && Is_ground && playable1)
        {
            velocity.y = Mathf.Sqrt(-30f * gravity);
        }
     
        
        if(Input.GetKeyDown(KeyCode.Q) && q_time>=100f)
        {
            if(final)
            {
                gulle_sayac_b = true;
                q_time = 0f;
            }
        }


        if(gulle_sayac_b)
        {
            gulle_sayac += Time.deltaTime;
            if(gulle_sayac>=0.4f)
            {
                Instantiate(playerGulle, gullePoint.position, Quaternion.identity);
                gulle_sayac = 0f;
                gulle_sayac_b = false;
            }
        }

    }

}
