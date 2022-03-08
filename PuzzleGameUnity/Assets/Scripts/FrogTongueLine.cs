using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogTongueLine : MonoBehaviour
{
    #region Variables
    public bool drawTongue = false;
    private LineRenderer line;
    private Transform objLocation;
    public Transform frogTongue;
    public FrogTongue tongue;
    private ObstacleConnect connection;

    public LineRenderer lr;
    private List<Transform> points;
    #endregion

    static public FrogTongueLine s;

    // Start is called before the first frame update
    void Start()
    {


    }
    void Awake()
    {

        drawTongue = false;
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame

    public void SetUpLine(List<Transform> points)
    {
        lr.positionCount = points.Count;
        this.points = points;
    }

    public void GetPoints(Transform loc)
    {
        drawTongue = true;
        while (drawTongue)
        {
            points.Add(objLocation);
            points.Add(loc);
            SetUpLine(points);
        }
        
    }

 /*   void Update()
    {
        if (drawTongue)
        {
            if (tongue.GetTarget() != null)
            {
                objLocation = tongue.GetTarget();
                for (int i = 0; i < points.Count - 1; i++)
                {
                    lr.SetPosition(i, points[i].position);
                }
            }
        }
    }*/
}