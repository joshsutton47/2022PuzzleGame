using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogTongueLine : MonoBehaviour
{
    #region Variables
    private bool drawTongue = false;
    private LineRenderer line;
    private Vector3 objLocation;
    public GameObject frogTongue;
    private List<Vector3> points;
    public FrogTongue tongue;
    #endregion

    static public FrogTongueLine s;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {

        drawTongue = false;
        line.enabled = false;
        //frogTongue = this.gameObject;
        points = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tongue.GetTarget() != null)
        {
            drawTongue = true;
            objLocation = tongue.GetTarget();

        }
        if (!drawTongue)
        {
            points.Add(frogTongue.transform.position);
            points.Add(objLocation);


            line.enabled = true;


        }
    }

    public void clearTongue()
    {
        line.enabled = false;
        points = new List<Vector3>();

    }
}