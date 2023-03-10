using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class lineController : MonoBehaviour
{
    [SerializeField] Vector3[] points;
    [SerializeField]LineRenderer lr;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    public void SetUpLine(Vector3[] points)
    {
        
        lr.positionCount = points.Length;
        this.points = points;
        for(int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i]);
        }
        Instantiate(lr);
    }
}
