using System;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] mainPathPoints;
    public static Transform[] altPathPoints;

    void Awake()
    {
        Transform mainPath = transform.GetChild(0);
        mainPathPoints = new Transform[mainPath.childCount];
        for (int i = 0; i < mainPathPoints.Length; i++)
        {
            mainPathPoints[i] = mainPath.GetChild(i);
        }

        Transform altPath = transform.GetChild(1);
        altPathPoints = new Transform[altPath.childCount];
        for (int i = 0; i < altPathPoints.Length; i++)
        {
            altPathPoints[i] = altPath.GetChild(i);
        }
    }
}
