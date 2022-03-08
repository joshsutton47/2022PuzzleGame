using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FrogJump : MonoBehaviour
{
    #region Variables
    private bool canJump;
    private Vector3 currentPos;
    private Transform aimPos;
    public float maxVelocity;
    public float velocityMult = 8f;
    public float maxMagnitude = 3;
    public GameManager frogManager;
    public int totalJumps = 100;
    Rigidbody frogBody;
    public Frog froggy;
    public Text jumpText;


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        frogBody = this.GetComponent<Rigidbody>();
        canJump = true;
    }

    public int getRemainingJumps;

    public bool getJump()
    {
        return canJump;
    }

    void Update()
    {
        if(totalJumps <= 0)
        {
            froggy.died = true;
        }
        if (canJump)
        {
            currentPos = this.transform.position;
            Vector3 mousePos2D = Input.mousePosition;
            mousePos2D.z = -Camera.main.transform.position.z;
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
            Vector3 mouseDelta = mousePos3D - currentPos;
            
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
                totalJumps--;
                jumpText.text = "Jumps Remaining: " + totalJumps;

            }

        }
        else if (frogBody.velocity == Vector3.zero)
        {
            canJump = true;
        }
        if (froggy.died)
        {
            canJump = true;
        }

    }
}
