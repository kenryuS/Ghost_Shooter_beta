using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerScript : MonoBehaviour
{
    public static float diffvalfact;

    public static void playerDied()
    {
        SceneManager.LoadScene("GameOver");
    }

    public static void gameStart() {
        SceneManager.LoadScene("Main");
    }

    // Update is called once per frame
    void Update()
    {
        if ((SceneManager.GetActiveScene()).name == "GameOver" && Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("StartMenu");
        }
    }
}
