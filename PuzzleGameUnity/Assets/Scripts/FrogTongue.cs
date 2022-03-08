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
    public FrogTongueLine tLine;
    #endregion

    public Vector3 GetTarget()
    {
        if (closestObj != null)
        {
            return closestObj;
        }
        return Vector3.zero;
    }

    /*
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
        if (nearObjs.Contains(other.gameObject))
        {
            nearObjs.Remove(other.gameObject);
        }
    }*/
    void Start()
    {
        frogBody = this.GetComponent<Rigidbody>();
        nearObjs = new List<GameObject>();
    }
    public void MoveFrogTo(GameObject target)
    {
        if (!frog.getJump())
        {
            frogLocation = this.transform.position;
            closestObj = target.transform.position;
            Vector3 distDelta = closestObj - frogLocation;
            frogBody.velocity = distDelta * 2;

        }
    }
}