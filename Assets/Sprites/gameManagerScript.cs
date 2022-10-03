using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerScript : MonoBehaviour
{
    public static int difficulty;
    public static float diffvalfact;

    public static void playerDied()
    {
        SceneManager.LoadScene("GameOver");
    }

    // Update is called once per frame
    void Start()
    {
        if (difficulty == 1) diffvalfact = 0.5f;
        if (difficulty == 2) diffvalfact = 1.0f;
        if (difficulty == 3) diffvalfact = 1.75f;
    }
}
