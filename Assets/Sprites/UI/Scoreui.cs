using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreui : MonoBehaviour
{

    GameObject uiscore;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.uiscore = GameObject.Find("Score");
        this.uiscore.GetComponent<Text>().text = "Score: 0";
    }

    public void updateui()
    {
        this.score += 1;
        this.uiscore.GetComponent<Text>().text = "Score: " + score.ToString();
    }
}
