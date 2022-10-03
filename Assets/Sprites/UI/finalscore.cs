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
        this.finScore = (Scoreui.score + Timerui.time) * gameManagerScript.diffvalfact;
        uiFinalScore.text = "Kill score: +" + Scoreui.score + "\n" + "Time: +" + Timerui.time + "s\n" + "Final Score: " + this.finScore;
    }
}
