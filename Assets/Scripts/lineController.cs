/// <summary>
/// Linjos generatorius
/// Padavus taskus("points") perjuos sukuria linija "lr"
/// 
/// </summary>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class lineController : MonoBehaviour
{
    [SerializeField] Vector3[] points;
    [SerializeField]LineRenderer lr;

    //Iskvieciama pries Start() metoda
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    /// <summary>
    /// Sukuria linija pagal paduotus taskus
    /// </summary>
    /// <param name="points"></param>
    public void SetUpLine(Vector3[] points)
    {
        
        lr.positionCount = points.Length;
        this.points = points;

        for(int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i]);//irasomi taskai i linijos klase
        }
        Instantiate(lr);//sukuriama linija
    }
}
