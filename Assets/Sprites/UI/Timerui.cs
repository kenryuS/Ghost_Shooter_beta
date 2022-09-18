using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timerui : MonoBehaviour
{
    GameObject uitimer;
    float delta;
    float span = 1.0f;
    int time;

    // Start is called before the first frame update
    void Start()
    {
        this.uitimer = GameObject.Find("Timer");
        this.uitimer.GetComponent<Text>().text = "Time: 0s";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.delta += Time.fixedDeltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            this.time += 1;
            this.uitimer.GetComponent<Text>().text = "Time: " + time.ToString() + "s";
        }
    }
}
