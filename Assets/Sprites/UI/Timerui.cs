using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timerui : MonoBehaviour
{
    GameObject uitimer;
    float delta;
    float span = 1.0f;
    public static int time;

    // Start is called before the first frame update
    void Start()
    {
	time = 0;
        this.uitimer = GameObject.Find("Timer");
        this.uitimer.GetComponent<Text>().text = "Time: 0s";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManagerScript.isPaused == true) {return;}
        this.delta += Time.fixedDeltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            time += 1;
            this.uitimer.GetComponent<Text>().text = "Time: " + time.ToString() + "s";
        }
    }
}
