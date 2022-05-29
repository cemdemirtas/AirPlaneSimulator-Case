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
        //I prefer slider instead of gas or break pedal.

        speed = speedSlider.value;
        AircraftMovement.instance.forwardSpeed = speed;
    }


}
