using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ilk_info : MonoBehaviour
{
    public GameObject player;
    public GameObject mouse_aktiflik;
    public GameObject yonerge06;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        
    }


    public void kapat()
    {
        mouse_aktiflik.GetComponent<Camera_controller>().playable = true;
        yonerge06.SetActive(false);
        player.GetComponent<Player_movements>().playable0 = true;
        player.GetComponent<Player_movements>().playable1 = true;
    }

    public void ac()
    {
        mouse_aktiflik.GetComponent<Camera_controller>().playable = false;
        player.GetComponent<Player_movements>().playable0 = false;
        player.GetComponent<Player_movements>().playable1 = false;
    }

    public void ana_menu()
    {
        SceneManager.LoadScene("Baslangic");
    }

    public void anubis_yukle()
    {
        SceneManager.LoadScene("anubis_fight");
    }

    public void mumya_yukle()
    {
        SceneManager.LoadScene("mumya_dovus");
    }

    public void col_yukle()
    {
        SceneManager.LoadScene("Tefnut_opening");
    }

    public void piramit_ici_yukle()
    {
        SceneManager.LoadScene("Piramit_ici");
    }

    public void hazýrlayan()
	{
        SceneManager.LoadScene("hazýrlayan");
    }


}
