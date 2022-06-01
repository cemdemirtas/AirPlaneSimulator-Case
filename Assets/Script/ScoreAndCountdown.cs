using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreAndCountdown : MonoBehaviour
{
    public static ScoreAndCountdown instance;
    float score=100;
    float Countdown = 150;
    public TextMeshProUGUI scoretxt, countdowntxt,losetxt;
    public Transform airplane;

    private void Awake() //Singleton
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        Countdown -= Time.deltaTime;
        countdowntxt.text = "TIME : " + Mathf.Round(Countdown);

        if (Countdown < 0)
        {
            GameManager.Instance.gamestate = GameManager.GameState.GameOver; //game over state

            airplane.GetComponent<SphereCollider>().isTrigger = false;
            airplane.GetComponent<Rigidbody>().isKinematic = true;
            airplane.GetComponent<AircraftMovement>().enabled = false; //Deactive movememnt of AirCraft
        }
        if (Countdown<=0)
        {
            Countdown = 0;
        }
    }
    public float ScoreAdd(float scr) //Increase Score by reference other script
    {
        score += scr;
        ControlScore();
        return score;
    }

    public float ScoreSubstract(float scr) //Decrease Score by reference other script
    {
        score -= scr;
        ControlScore();
        return score;
    }

    private void ControlScore() //Text write
    {
        scoretxt.text = "Score : " + (((int)score));
        if (score<=0)
        {
            GameManager.Instance.gamestate = GameManager.GameState.GameOver; //game over state
            airplane.GetComponent<SphereCollider>().isTrigger = false;
            airplane.GetComponent<Rigidbody>().isKinematic = true;
            airplane.GetComponent<AircraftMovement>().enabled = false; //Deactive movememnt of AirCraft
        }
    }

}
