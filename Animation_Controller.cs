using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Controller : MonoBehaviour
{
    private bool walk_ani;
    private bool fast_ani;
    public Transform down_ani_checker;
    private bool down_ani;
    public LayerMask obstacle;
    public float i = 0;
    public bool i_sayac=false;
    private float zopa_zaman = 0;
    private int zopa_sayisi=0;
    private bool zopa_sayac=false,e_sayac_control=false;
    public float e_sayac = 100f;
    public GameObject PUNCH_VFX;
    public Transform shotloc;
    Vector3 effect_yon;

    private void Update()
    {
        down_ani = Physics.CheckSphere(down_ani_checker.position, 0.1f, obstacle);
    }


    void LateUpdate()
    {

        //Yürüme Animasyonu

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            walk_ani = true;
        }

        else
        {
            walk_ani = false;
            
        }

        
        if (walk_ani)
        {
             GetComponent<Animator>().SetTrigger("walk_p");
        }

        else
        {
            GetComponent<Animator>().SetTrigger("walk_n");
        }
        

        //Hýzlý Koþma Animasyonu

        if (walk_ani&&Input.GetMouseButton(1))
        {
            fast_ani = true;   
        }

        else
        {
            fast_ani = false;
        }

        if(fast_ani)
        {
            GetComponent<Animator>().SetTrigger("fast_p");
        }

        else
        {
            GetComponent<Animator>().SetTrigger("fast_n");
        }



        //Zýplama Animasyonu
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Animator>().SetTrigger("jump_ani");
            i_sayac = true;    
        }

        if(i_sayac)
        {
            i += Time.deltaTime;
        }

        if(i>0.7)
        {
            GetComponent<Animator>().SetTrigger("down_ani_n");
            i_sayac = false;
            i = 0;
        }


        //Zopa Animasyonlarý

        if (Input.GetMouseButtonDown(0))
        {
            if(zopa_zaman>0f&&zopa_zaman<2f)
            {
                zopa_zaman = 0f;
            }
            zopa_sayac = true;
            zopa_sayisi++;
        }


        if (zopa_sayac)
        {
            zopa_zaman += Time.deltaTime;
        }

        else
        {
            zopa_zaman = 0;
        }


        if(zopa_zaman>=0f && zopa_zaman<2f)
        {
           switch(zopa_sayisi)
            {
                case 1:
                    GetComponent<Animator>().SetTrigger("p1");
                    GetComponent<Animator>().SetTrigger("p_idle");
                    float angle = Mathf.LerpAngle(0, transform.rotation.y, Time.time);
                    shotloc.eulerAngles = new Vector3(0f, 0f, angle);
                    Vector3 o1 = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
                    Instantiate(PUNCH_VFX, shotloc.position, Quaternion.Euler(o1) * transform.rotation);
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.Space))
                    {
                        GetComponent<Animator>().SetTrigger("back_main_idle");
                    }
                    zopa_sayisi++;
                    break;

                case 3:
                    GetComponent<Animator>().ResetTrigger("p1");
                    GetComponent<Animator>().SetTrigger("p2");
                    GetComponent<Animator>().SetTrigger("p_idle");
                    Vector3 o2 = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
                    Instantiate(PUNCH_VFX, shotloc.position, Quaternion.Euler(o2) * transform.rotation);
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.Space))
                    {
                        GetComponent<Animator>().SetTrigger("back_main_idle");
                    }
                    zopa_sayisi++;
                    break;

                case 5:
                    GetComponent<Animator>().ResetTrigger("p2");
                    GetComponent<Animator>().SetTrigger("p3");
                    GetComponent<Animator>().SetTrigger("p_idle");
                    Vector3 o3 = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
                    Instantiate(PUNCH_VFX, shotloc.position,Quaternion.Euler(o3)*transform.rotation);
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.Space))
                    {
                        GetComponent<Animator>().SetTrigger("back_main_idle");
                    }
                    zopa_sayisi++;
                    break;

                case 6:
                    zopa_sayisi = 0;
                    break;
            }            
        }
        
        else
        {
            zopa_sayac = false;
            zopa_sayisi = 0;
            GetComponent<Animator>().SetTrigger("back_main_idle");
        }


        //Super Combat
        if(Input.GetKeyDown(KeyCode.E) && e_sayac>=100f)
        {
            e_sayac_control = true;
            e_sayac = 0f;
            Vector3 o4 = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            Instantiate(PUNCH_VFX, shotloc.position, Quaternion.Euler(0f, 0f, 0f)*transform.rotation*Quaternion.Euler(o4));
            Instantiate(PUNCH_VFX, shotloc.position , Quaternion.Euler(0f, 90f, 0f)*transform.rotation*Quaternion.Euler(o4));
            Instantiate(PUNCH_VFX, shotloc.position , Quaternion.Euler(0f, 180f, 0f)*transform.rotation*Quaternion.Euler(o4));
            Instantiate(PUNCH_VFX, shotloc.position , Quaternion.Euler(0f, 270f, 0f)*transform.rotation*Quaternion.Euler(o4));
            GetComponent<Animator>().SetTrigger("combat_p");
        }

        if (e_sayac_control)
        {
            e_sayac += Time.deltaTime * 10f;
            if (e_sayac >= 100f)
            {
                e_sayac_control = false;
            }
        }

        else
        {
            e_sayac = 100f;
        }


        if (Input.GetKeyDown(KeyCode.Q) && GetComponent<Player_movements>().q_time >= 100f)
        {
            GetComponent<Animator>().SetTrigger("ayýb2_p");
        }

    }
}
