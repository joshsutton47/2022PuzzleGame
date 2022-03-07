using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleConnect : MonoBehaviour
{
    public bool clickable = false;

    private Rigidbody connectRB;
    private void OnTriggerEnter(Collider other)
    {
        
       
        
    }

    public void OnMouseOver()
    {
        clickable = true;    
    }

    public void OnMouseExit()
    {
        clickable = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Frog"))
        {
            connectRB = collision.gameObject.GetComponent<Rigidbody>();
            connectRB.useGravity = false;
            connectRB.velocity = Vector3.zero;
            connectRB.angularVelocity = Vector3.zero;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
