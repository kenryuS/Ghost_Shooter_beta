using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diffslide : MonoBehaviour
{
    public Text label;
    public Slider diffislide;
    public static string difficulty;
    public static float diffval;

    // Update is called once per frame
    void Update()
    {
        diffval = diffislide.value;
        if (diffval == 1.0f) {
            label.text = "Difficulty: Easy";
            difficulty = "Easy";
        }
        if (diffval == 2.0f) {
            label.text = "Difficulty: Normal";
            difficulty = "Normal";
        }
        if (diffval == 3.0f) {
            label.text = "Difficulty: Hard";
            difficulty = "Hard";
        }
    }
}
