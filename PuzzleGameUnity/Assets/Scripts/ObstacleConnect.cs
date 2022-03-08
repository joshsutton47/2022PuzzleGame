using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleConnect : MonoBehaviour
{
    public FrogTongue tongue;

    //public FrogTongueLine tLine;
    private Rigidbody connectRB;

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //tLine.drawTongue = true;
            //tLine.GetPoints(this.gameObject.transform);
            tongue.MoveFrogTo(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Frog"))
        {
            //tLine.drawTongue = false;
            connectRB = collision.gameObject.GetComponent<Rigidbody>();
            connectRB.useGravity = false;
            connectRB.velocity = Vector3.zero;
            connectRB.angularVelocity = Vector3.zero;
        }
    }
}
