using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Terrain")
        {
            Debug.Log("we hit");
            transform.GetComponent<SphereCollider>().isTrigger = false;
            transform.GetComponent<Rigidbody>().isKinematic = true;
            transform.GetComponent<AircraftMovement>().enabled = false; //Deactive movememnt of AirCraft
            InvokeRepeating("CallExpolisonFunction", 0, 1);
            transform.GetChild(4).GetComponent<MeshRenderer>().material.color = Color.grey; //turn over color to grey when hit terrain.
            EffectsController.instance.StopNozzleEffect();
        }
    }

    void CallExpolisonFunction() // for invokeRepeating
    {
        EffectsController.instance.ExplosionCall();
    }
}
