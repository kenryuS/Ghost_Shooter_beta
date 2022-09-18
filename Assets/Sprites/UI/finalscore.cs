using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalscore : MonoBehaviour
{
    public Text uiFinalScore;
    public float finScore;
    public int killscore = Scoreui.score;
    public int timeScore = Timerui.time;

    void Start()
    {
        finScore = Scoreui.score + timeScore;
        uiFinalScore.text = "Final Score: " + finScore;
    }
}
