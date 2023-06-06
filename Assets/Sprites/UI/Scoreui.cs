using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreui : MonoBehaviour
{

    GameObject uiscore;
    public static int score = 0;

	public static void addMonsterKill() {
	    score += 100;
	}

	public static void addWaveBonus() {
	    score += 1_000;
	}

	public static void addGameClearBonus() {
        score += 100_000;
	}

    // Start is called before the first frame update
    void Start()
    {
        this.uiscore = GameObject.Find("Score");
        this.uiscore.GetComponent<Text>().text = "Score: 0";
    }

    void Update()
    {
        this.uiscore.GetComponent<Text>().text = "Score: " + score.ToString();
    }
}
