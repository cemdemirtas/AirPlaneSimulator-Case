using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    public static EffectsController instance;

   [SerializeField] ParticleSystem[] explosions;
   [SerializeField] ParticleSystem[] NozzleEffects;

    private void Awake() //Singleton
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        foreach (var item in explosions) //reach whole list to do not play on the begining
        {
            item.Stop();
        }
    }

    public void ExplosionCall()  //when we hit
    {
        foreach (var item in explosions)
        {
            item.Play();
        }
    }
    public void StopNozzleEffect()
    {
        foreach (var item in NozzleEffects)
        {
            item.Stop();
        }
    }

}
