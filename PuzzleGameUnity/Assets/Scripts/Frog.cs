using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public bool died = false;
    private Rigidbody frogBody;

    private void Awake()
    {
        frogBody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hazard")
        {
            died = true;
        }
    }

    public void StopMovement()
    {
        frogBody.velocity = Vector3.zero;
        frogBody.angularVelocity = Vector3.zero;
    }
}
