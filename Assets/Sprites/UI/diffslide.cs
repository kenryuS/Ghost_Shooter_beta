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

    void Start()
    {
        diffval = 1;
        ValueChanged(this.diffislide);
        diffislide.onValueChanged.AddListener(delegate {
            ValueChanged(this.diffislide);
        });
    }

    void ValueChanged(Slider c) {
        diffval = c.value;
        if (diffval == 1.0f) {
            label.text = "Easy";
            difficulty = "Easy";
            monstergen.spawnRate = (1.0f)/(0.5f);
            gameManagerScript.diffvalfact = 0.5f;
        }
        else if (diffval == 2.0f) {
            label.text = "Normal";
            difficulty = "Normal";
            monstergen.spawnRate = 1.0f;
            gameManagerScript.diffvalfact = 1.0f;
        }
        else if (diffval == 3.0f) {
            label.text = "Hard";
            difficulty = "Hard";
            monstergen.spawnRate = (1.0f)/(1.5f);
            gameManagerScript.diffvalfact = 1.5f;
        }
    }
}
