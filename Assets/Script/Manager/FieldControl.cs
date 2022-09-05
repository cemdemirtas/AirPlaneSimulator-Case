using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FieldControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI warningText;
    void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(transform.position);
        RaycastHit hit;
        if (ray.origin.x < 550 || ray.origin.x > 800 || ray.origin.y>-40 ||  -300 >ray.origin.y ) //control different position and show some warning message
        {
            InvokeRepeating("WarningTxtActive", 0, 1f);
            ScoreAndCountdown.instance.ScoreSubstract(0.1f);
        }
        else
        {
            CancelInvoke();
            warningText.gameObject.SetActive(false);

        }
    }
    private void Update()
    {
        //clamp aircraft movement
       transform.position = new Vector3( Mathf.Clamp(transform.position.x,400, 1000), Mathf.Clamp(transform.position.y, -400, 10),transform.position.z);
    }
    void WarningTxtActive()
    {
        warningText.gameObject.SetActive(true);

    }


}
