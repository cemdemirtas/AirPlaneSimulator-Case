using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score instance;
    int score;
    public TextMeshProUGUI scoretxt;

    private void Awake() //Singleton
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    private void Update()
    {

    }
    public int ScoreAdd(int scr) //Increase Score by reference other script
    {
        score += scr;
        ControlScore();
        return score;
    } 
    
    public int ScoreSubstract(int scr) //Decrease Score by reference other script
    {
        score -= scr;
        ControlScore();
        return score;
    }

    private void ControlScore() //Text write
    {
        scoretxt.text ="Score : " + score;
    }
}
