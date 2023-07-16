using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class esc_menu : MonoBehaviour
{
    private bool aktif = false;
    public GameObject player, cam;
    public GameObject esc_menusu;
    public GameObject seslendirme;
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam= GameObject.FindGameObjectWithTag("camera_ayarlari");
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(aktif)
            {
                esc_menusu.SetActive(true);
                player.GetComponent<Player_movements>().playable0 = false;
                player.GetComponent<Player_movements>().playable1 = false;
                cam.GetComponent<Camera_controller>().playable = false;
                aktif = false;
            }

            else
            {
                esc_menusu.SetActive(false);
                player.GetComponent<Player_movements>().playable0 = true;
                player.GetComponent<Player_movements>().playable1 = true;
                cam.GetComponent<Camera_controller>().playable = true;
                aktif = true;
            }

        }

    }

    public void ana_menu()
    {
        SceneManager.LoadScene("Baslangic");
    }

    public void devam_et()
    {
        esc_menusu.SetActive(false);
        player.GetComponent<Player_movements>().playable0 = true;
        player.GetComponent<Player_movements>().playable1 = true;
        cam.GetComponent<Camera_controller>().playable = true;
        aktif = true;
    }

    public void changeT()
    {
        seslendirme.GetComponent<seslendirmeler2>().j_t = false;
        esc_menusu.SetActive(false);
        player.GetComponent<Player_movements>().playable0 = true;
        player.GetComponent<Player_movements>().playable1 = true;
        cam.GetComponent<Camera_controller>().playable = true;
        aktif = true;
    }

    public void changeJ()
    {
        seslendirme.GetComponent<seslendirmeler2>().j_t = true;
        esc_menusu.SetActive(false);
        player.GetComponent<Player_movements>().playable0 = true;
        player.GetComponent<Player_movements>().playable1 = true;
        cam.GetComponent<Camera_controller>().playable = true;
        aktif = true;
    }


    public void changeTF()
    {
        seslendirme.GetComponent<Seslendirmeler>().j_t = false;
        esc_menusu.SetActive(false);
        player.GetComponent<Player_movements>().playable0 = true;
        player.GetComponent<Player_movements>().playable1 = true;
        cam.GetComponent<Camera_controller>().playable = true;
        aktif = true;
    }

    public void changeJF()
    {
        seslendirme.GetComponent<Seslendirmeler>().j_t = true;
        esc_menusu.SetActive(false);
        player.GetComponent<Player_movements>().playable0 = true;
        player.GetComponent<Player_movements>().playable1 = true;
        cam.GetComponent<Camera_controller>().playable = true;
        aktif = true;
    }



}
