using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogJump : MonoBehaviour
{
    #region Variables
    private bool canJump;
    private Vector3 currentPos;
    private Transform aimPos;
    public float maxVelocity;
    public float velocityMult = 8f;

    Rigidbody frogBody;


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        frogBody = this.GetComponent<Rigidbody>();
        canJump = true;
    }

    private void OnMouseDown()
    {
        //frogBody.isKinematic = true;
    }

    public bool getJump()
    {
        return canJump;
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump)
        {
            currentPos = this.transform.position;
            Vector3 mousePos2D = Input.mousePosition;
            mousePos2D.z = -Camera.main.transform.position.z;
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
            Vector3 mouseDelta = mousePos3D - currentPos;
            float maxMagnitude = this.GetComponent<SphereCollider>().radius;
            if (mouseDelta.magnitude > maxMagnitude)
            {
                mouseDelta.Normalize();
                mouseDelta *= maxMagnitude;
            }

            if (Input.GetMouseButtonUp(0))
            {
                canJump = false;
                frogBody.useGravity = true;
                frogBody.velocity = mouseDelta * velocityMult;

            }

        }
        else if (frogBody.velocity == Vector3.zero)
        {
            canJump = true;
        }
       
    }
}
