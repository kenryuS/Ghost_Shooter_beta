using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreui : MonoBehaviour
{

    GameObject uiscore;
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
	score = 0;
        this.uiscore = GameObject.Find("Score");
        this.uiscore.GetComponent<Text>().text = "Difficulty: " + diffslide.difficulty + " Kills: 0";
    }

    public void updateui()
    {
        score += 1;
        this.uiscore.GetComponent<Text>().text = "Difficulty: " + diffslide.difficulty + " Kills: " + score.ToString();
    }
}
