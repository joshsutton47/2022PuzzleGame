using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fly : MonoBehaviour
{
    public bool flyCaught;

    private void Awake()
    {
        flyCaught = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Frog")
        {
            flyCaught = true;
            SceneManager.LoadScene("Level2");
        }
    }
}
