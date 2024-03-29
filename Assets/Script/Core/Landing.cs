using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class Landing : MonoBehaviour
{
    public static Landing instance;

    PathMode pm;
    PathType pt;
    public Vector3[] LandingPoint;
    public Transform airCraft;
    [SerializeField]TextMeshProUGUI succestxt;

    private void Awake() //Singleton
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CallLanding()
    {
        airCraft.DOPath(LandingPoint, 5, pt, pm);
        AircraftMovement.instance.ForwardSpeed = 0f; // when we landing speed set 0
        //succestxt.gameObject.SetActive(true);
        InvokeRepeating("SuccessEffect", 1f, 1f); // call releated effect when we finish the checkpoints.

    }

    void SuccessEffect()
    {
        EffectsController.instance.CheckPointHit(); // Conffetti effect

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            GameManager.Instance.gamestate = GameManager.GameState.Next; //Next Level State

        }
    }
}
