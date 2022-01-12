using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lrtesting : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private linerender line;

    private void Start() {

        line.SetUpLine(points);
    }
}
