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
        float Value = 40 / GetYPos;
        progressBarImage.fillAmount = Mathf.Abs(Value);
        FeetTxt.text = "Feet: " + Mathf.Abs(Value*10).ToString(); // Get Feet value
    }
}
