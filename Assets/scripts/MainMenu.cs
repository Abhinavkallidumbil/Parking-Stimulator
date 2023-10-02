using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void FreeRoam()
    {
        SceneManager.LoadScene("FreeRoam");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Parking()
    {
        SceneManager.LoadScene("Parkingmenu");
    }
}
