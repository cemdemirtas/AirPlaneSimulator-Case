using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Transform[] checkpoints;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AirCraft")
        {
            ScoreAndCountdown.instance.ScoreAdd(500); // Use singleton to reach score's from other script.
            this.gameObject.SetActive(false);
            EffectsController.instance.CheckPointHit();
        }
    }


}
