using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Landing : MonoBehaviour
{
    public static Landing instance;

    PathMode pm;
    PathType pt;
    public Vector3[] LandingPoint;

    public Transform airCraft;

    private void Awake() //Singleton
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CallLanding()
    {
        airCraft.DOPath(LandingPoint, 15, pt, pm);
        airCraft.DORotate(new Vector3(0,0,0),15);
        AircraftMovement.instance.forwardSpeed = 0f; // when we landing speed set 0
    }
}
