using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
 [SerializeField] Transform[] CheckPoints;

    private void Update()
    {
       
            if (transform.GetChild(CheckPoints.Length-1).gameObject.active==false) //when we setactive false last checkpoints.
            {
            Debug.Log("okey");
            }
        
    }
}
