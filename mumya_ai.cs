using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class mumya_ai : MonoBehaviour
{

    public Transform player;
    public GameObject Player;
    public float stop_distance;
    private float distance;
    NavMeshAgent mumya;
    public float mumya_health = 100f;
    public bool yumruk;
    public Transform yumruk_check;
    public LayerMask Player_layer;
    private bool vur_zamani;
    private float vur_sayac;
    private float olum_sayac;
    private bool olum_button;
    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Player = GameObject.FindGameObjectWithTag("Player");

    }
    
    private void Start()
    {
        mumya = GetComponent<NavMeshAgent>();
    }



    private void Update()
    {

        //Mumya ile Player arasý mesafe
        distance = Vector3.Distance(transform.position, player.position);


        //Mumyanýn player'a dönmesi
        transform.LookAt(player.position);


        //Hedef belirleme
        mumya.destination = player.position;



        //Animasyon Kontrolleri
        if(distance<=stop_distance)
        { 
            GetComponent<Animator>().SetTrigger("yuruyus_n");
            GetComponent<Animator>().SetTrigger("dovus_p");
            vur_zamani = true;
        }
       
        else
        {
            GetComponent<Animator>().SetTrigger("dovus_n");
            GetComponent<Animator>().SetTrigger("yuruyus_p");
            vur_zamani = false;
        }


        if(mumya_health<=0f)
        {
            olum_button = true;
            GetComponent<Animator>().SetTrigger("mumya_olum");
            if (olum_button)
            {
                olum_sayac += Time.deltaTime;
            }

            if (olum_sayac>=1.3f)
            {
                olum_sayac = 0;
                olum_button = false;
                player.GetComponent<Player_movements>().olen_mumyalar++;
                Destroy(this.gameObject);
            }
            
        }



        //Mumya Hasarý
        yumruk = Physics.CheckBox(yumruk_check.position,new Vector3(9f,9f,9f),Quaternion.identity, Player_layer);


        if(yumruk && vur_zamani)
        {
            vur_sayac += Time.deltaTime;
            if(vur_sayac>=1f)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player_movements>().mumya_hasar = true;
                vur_sayac = 0;
            }
        }


        //Player'ýn Hasarý
        if(yumruk && Input.GetMouseButtonDown(0))
        {
            mumya_health -= 20f;
        }


        if(yumruk && Input.GetKeyDown(KeyCode.E) && Player.GetComponent<Animation_Controller>().e_sayac==100f)
        {
            mumya_health -= 100f;
        }


    }


}
