using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpeedControl : MonoBehaviour
{
    public Slider speedSlider;
    [SerializeField] float speed = 0;
    [SerializeField] TextMeshProUGUI Speedtxt;
    [SerializeField] Image SpeedProgress ;
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
        Speedtxt.text = "Speed: "+ Mathf.Round(AircraftMovement.instance.forwardSpeed*40).ToString(); // reach speed value using by singleton
        SpeedProgress.fillAmount = (AircraftMovement.instance.forwardSpeed * 40) / 800;
    }



}
