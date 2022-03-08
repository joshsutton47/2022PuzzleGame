using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }
}
