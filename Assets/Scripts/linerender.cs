using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linerender : MonoBehaviour
{
    private Transform[] points;
    LineRenderer LR;


    private void Awake()
    {
        LR = GetComponent<LineRenderer>();

    }

    public void SetUpLine(Transform[] points)
    {
        LR.positionCount = points.Length;
        this.points = points;
    }

    private void Update() 
    {
        for (int i =0; i < points.Length; i++)
        {
            LR.SetPosition(i, points[i].position);
        }
    }
}
