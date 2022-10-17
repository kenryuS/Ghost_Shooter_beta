using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalscore : MonoBehaviour
{
    public Text uiFinalScore;
    public float finScore;

    void Start()
    {
        finScore = (Scoreui.score + Timerui.time) * gameManagerScript.diffvalfact;
        uiFinalScore.text = "Kill score: +" + Scoreui.score + "\n" + "Time: +" + Timerui.time + "s\n" + "Difficulty: " + gameManagerScript.diffvalfact + "x\n" + "Final Score: " + finScore;
    }
}
