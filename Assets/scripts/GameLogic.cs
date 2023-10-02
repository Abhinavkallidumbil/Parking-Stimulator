using JetBrains.Annotations;
using System.Threading;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public int LivesNumber = 3;
    public GameObject live1;
    public GameObject live2;
    public GameObject live3;




    Vector3 startPos;
    Quaternion startRot;

    public Vector3 initialPositionnew;
    public Quaternion initialRotationnew;

    public GameObject LoseMenu;

    private void Start()
    {
        initialPositionnew = transform.position;
        initialRotationnew = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            Lives();
        }
    }

    public void SceneReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Lives()
    {
        LivesNumber--;
        if (LivesNumber == 2) { live3.SetActive(false); Reset(); }
        if (LivesNumber == 1){ live2.SetActive(false); Reset(); }
        if(LivesNumber == 0)
        {
            live1.SetActive(false);
            LoseMenu.SetActive(true);
            
        }
    }
    private void Reset()
    {
        transform.position = initialPositionnew;
        transform.rotation = initialRotationnew;
    }
    public void ParkingMenu()
    {
        SceneManager.LoadScene("Parkingmenu");
    }

}
