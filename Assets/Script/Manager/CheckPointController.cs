using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    [SerializeField] Transform[] CheckPoints;
    [SerializeField] Transform Aircraft;
    private void Update()
    {
        //when we setactive false last checkpoints.
        if (transform.GetChild(CheckPoints.Length - 1).gameObject.active == false) 
        {
            Debug.Log("okey");
            Landing.instance.CallLanding();


        }
        // We don't hit last check point go landing
        if (Aircraft.transform.position.z+10f>transform.GetChild(CheckPoints.Length - 1).gameObject.transform.position.z)
        {
            Landing.instance.CallLanding();
        }

    }

}
