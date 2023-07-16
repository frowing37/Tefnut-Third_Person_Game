using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    

    public void Play()
    {
        SceneManager.LoadScene("Tefnut_opening");
    }

    public void Hazirlayan()
	{
        SceneManager.LoadScene("hazýrlayan");
    }

    public void anaMenü()
	{
        SceneManager.LoadScene("Baslangic");
    }

    public void Exit()
    {
        Application.Quit();
    }
    

    public void Settings()
    {

    }


}
