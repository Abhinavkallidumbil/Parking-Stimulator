using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public GameObject escMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleEscapeMenu();
        }
    }

    void ToggleEscapeMenu()
    {
        // Check if escMenu is not active, and activate it if it's not.
        // If it's already active, deactivate it.
        escMenu.SetActive(!escMenu.activeSelf);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("main menu");
    }
    public void Parking()
    {
        SceneManager.LoadScene("Parkingmenu");
    }
}
