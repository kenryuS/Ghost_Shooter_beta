using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diffslide : MonoBehaviour
{
    public Text label;
    public Slider diffislide;
    public static float diffvalue;

    // Update is called once per frame
    void Update()
    {
        diffvalue = diffislide.value;
        if (diffvalue == 1.0f) {
            label.text = "Difficulty: Easy";
        }
        if (diffvalue == 2.0f) {
            label.text = "Difficulty: Normal";
        }
        if (diffvalue == 3.0f) {
            label.text = "Difficulty: Hard";
        }
    }
}
