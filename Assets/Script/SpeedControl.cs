using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedControl : MonoBehaviour
{
    public Slider speedSlider;
    [SerializeField] float speed = 0;
    private void Start()
    {
        speedSlider.value = 0;
    }

    private void Update()
    {
        //If fit for you, i would like using slider instead of gas or break pedal.

        speed = speedSlider.value;
        AircraftMovement.instance.forwardSpeed = speed;
        if (speedSlider.value>1)
        {
            transform.GetComponent<Rigidbody>().isKinematic = false;

            //transform.GetComponent<SphereCollider>().isTrigger = true; // when we start the game, aircraft should on the takeOff Map.

        }
    }


}
