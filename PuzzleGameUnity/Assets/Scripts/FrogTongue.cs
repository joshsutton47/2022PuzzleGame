using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogTongue : MonoBehaviour
{
    #region Variables
    public FrogJump frog;
    private Vector3 closestObj;
    private List<GameObject> nearObjs;
    private Vector3 frogLocation;
    private Rigidbody frogBody;
    private float velocityMult = 2f;
    private bool jumping;

    private ObstacleConnect connection;
    #endregion
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            nearObjs.Add(other.gameObject);
            Debug.Log("Added game object");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            nearObjs.Remove(other.gameObject);
        }
    }

    /*private void OnMouseUp()
    {
        frogLocation = this.transform.position;
        foreach (GameObject close in nearObjs)
        {
            Vector3 distDelta = close.transform.position;//- frogLocation;
            //frogBody.velocity = close.transform.position * 3;

        }
    }*/

    public Vector3 GetTarget()
    {
        if(closestObj != null)
        {
            return closestObj;
        }
        return Vector3.zero;
    }


    // Start is called before the first frame update
    void Start()
    {

        frogBody = this.GetComponent<Rigidbody>();
        nearObjs = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null) { closestObj = hit.transform.position; }
            if (!frog.getJump())
            {
                frogLocation = this.transform.position;
                foreach (GameObject close in nearObjs)
                {
                    connection = close.GetComponent<ObstacleConnect>();
                    if (connection.clickable)
                    {
                    //    closestObj = close.transform.position;
                    }
                    else
                    {
                        return;
                    }
                    /*if (Vector3.Distance(close.transform.position, frogLocation) < Vector3.Distance(closestObj, frogLocation))
                    {
                        closestObj = close.transform.position;
                    }*/
                }
                Vector3 distDelta = closestObj - frogLocation;
                frogBody.velocity = distDelta * velocityMult;
            }

        }
    }
}