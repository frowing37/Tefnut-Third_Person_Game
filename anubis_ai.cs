using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anubis_ai : MonoBehaviour
{

    public Transform target;
    public GameObject laser_kontrol;
    public bool DON = false;
    private float donus=180f,olum_zamani=0f;
    private bool aktif_donus = false;
    public float anubis_health = 500f;
    public bool sayac = false;
    public float sure = 0f;
    private int hamle = 0;
    private bool mumya_cagir0 = false, buyule0 = false;

    public GameObject[] spawn_m;
    public GameObject ankha;
    public Transform anubis_h;
    public GameObject anubis_kanama;
    public GameObject anubis_yok_olma;
    public GameObject seslendirme;
    public GameObject oyun_sonu_menu;

	private void Awake()
	{
        seslendirme = GameObject.FindGameObjectWithTag("music");
    }

	public void anubis_olum()
    {
        olum_zamani +=Time.deltaTime;
        if(olum_zamani>2f)
        {
            seslendirme.GetComponent<Seslendirmeler>().tefnut02();
            seslendirme.GetComponent<Seslendirmeler>().tefnut03();
            Instantiate(anubis_yok_olma, anubis_h.position, Quaternion.identity);
            oyun_sonu_menu.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    public void anubis_hasar()
    {
        Instantiate(anubis_kanama, anubis_h.position, Quaternion.identity);
        anubis_health -= 50f;
        GetComponent<Animator>().SetTrigger("a_dmg");
        seslendirme.GetComponent<Seslendirmeler>().hasar_sira++;
    }

    public void mumya_cagir()
    {
        mumya_cagir0 = true;
        for (int i = 0; i < 4; i++)
        {
            spawn_m[i].GetComponent<anubis_mumyalarý>().aktif = true;
            spawn_m[i].GetComponent<anubis_mumyalarý>().ilk_aktif = true;
        }
    }

    public void buyule()
    {
        buyule0 = true;
        ankha.GetComponent<buyu_spawn>().aktif = true;
    }

    public void laser_aktif_et()
    {
        laser_kontrol.GetComponent<Laser>().aktif_mek = true;
    }

	void Update()
    {
        //Giriþte geriye dönüþ
        if(DON)
        {            
            if(donus>0f)
            {
                donus -= Time.deltaTime * 40;
            }

            else
            {
                donus =0f;
                DON = false;
                aktif_donus = true;
                sayac = true;
            }

            transform.rotation = Quaternion.Euler(0f, donus, 0f);
        }
        
        //Tefnutu izlemesi
        if(aktif_donus)
        {
            transform.LookAt(target);
        }

        //Anubis Saldýrýlarý
        if (sayac)
        {
            sure += Time.deltaTime;
        }

        if(sure>5f)
        {
            hamle++;
            sure = 0f;
        }

        switch(hamle)
        {
            case 1:
                buyule();
                hamle++;
                break;
            case 3:
                mumya_cagir();
                hamle++;
                break;
            case 8:
                laser_aktif_et();
                hamle = 0;
                break;
        }

        //Anubis animasyonlarý
        if (aktif_donus)
        {
            GetComponent<Animator>().SetTrigger("idle");
        }

        if(anubis_health<=0)
        {
            GetComponent<Animator>().SetTrigger("yok_ol");
            anubis_olum();
        }

        if(buyule0)
        {
            GetComponent<Animator>().SetBool("buyule",true);
            buyule0 = false;
        }
        else
        {
            GetComponent<Animator>().SetBool("buyule", false);
        }

        if(mumya_cagir0)
        {
            GetComponent<Animator>().SetBool("m_cagir", true);
            mumya_cagir0 = false;
        }
        else
        {
            GetComponent<Animator>().SetBool("m_cagir", false);
        }
    }
}
