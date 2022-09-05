using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ProgressBarControl : MonoBehaviour
{
    [SerializeField] Image progressBarImage;
    [SerializeField] TextMeshProUGUI FeetTxt;

    private void Update()
    {
        float GetYPos = AircraftMovement.instance.transform.position.y; // reach aircraft y position by using singleton
        float Value = Mathf.Floor(40f / (GetYPos / 30.48f));
        progressBarImage.fillAmount = Mathf.Abs(Value);
        FeetTxt.text = "Feet: " + Mathf.Abs(Value*10).ToString(); // Get Feet value
    }
}
