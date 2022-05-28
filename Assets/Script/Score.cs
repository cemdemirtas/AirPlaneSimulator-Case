using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score instance;
    int score;
    public TextMeshProUGUI scoretxt;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    private void Update()
    {

    }
    public int ScoreAdd(int scr)
    {
        score += scr;
        ControlScore();
        return score;
    } 
    
    public int ScoreSubstract(int scr)
    {
        score -= scr;
        ControlScore();
        return score;
    }

    private void ControlScore()
    {
        scoretxt.text ="Score : " + score;
    }
}
