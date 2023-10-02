using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPass : MonoBehaviour
{
    
    public GameObject winmenu;
    public GameObject Text;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            winmenu.SetActive(true);
            Time.timeScale = 0.0001f;
            Text.SetActive(false);

        }
    }

    public void OneLevelPass()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("main menu");
    }
}
