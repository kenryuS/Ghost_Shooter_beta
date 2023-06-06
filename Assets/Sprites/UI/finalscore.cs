using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalscore : MonoBehaviour
{
    public Text uiFinalScore;
	public Text gameMsg;
    public float finScore;

    void Start()
    {
        finScore = Scoreui.score + (Timerui.time * 100);
		finScore *= gameManagerScript.diffvalfact;
        if (gameManagerScript.isGameCompleted) {
		    uiFinalScore.text = "Kill: " + gameManagerScript.monsterKilled + "x100 pt\nWaves: " + gameManagerScript.wavesCompleted + "x1000 pt\nGame Clear Bonus: 100000pt\nGame Difficulty: " + gameManagerScript.diffvalfact + "x\nTotal: " + finScore;
			gameMsg.text = "Game Clear";
		}
		else {
		    uiFinalScore.text = "Kill: " + gameManagerScript.monsterKilled + "x100 pt\nWaves: " + gameManagerScript.wavesCompleted + "x1000 pt\nTime Left: " + Timerui.time + "x100 pt\nGame Difficulty: " + gameManagerScript.diffvalfact + "x\nTotal: " + finScore;
			gameMsg.text = "Game Over";
		}
    }
}
