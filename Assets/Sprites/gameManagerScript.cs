using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerScript : MonoBehaviour
{
    public static float diffvalfact;
	public static int waveNumber = 0;
	public static int secPerWave = 0;
	public static int wavesCompleted = 0;
	public static int monsterKilled = 0;
	public static bool isGameCompleted = false;
    public static bool isPaused = false;

    public GameObject pauseText;

    public static void playerDied()
    {
        SceneManager.LoadScene("GameOver");
		Debug.Log(wavesCompleted);
    }

    public static void gameStart() {
		isGameCompleted = false;
		wavesCompleted = 0;
		monsterKilled = 0;
		Scoreui.score = 0;
        SceneManager.LoadScene("Main");
    }

	public static void gameCompleted() {
		isGameCompleted = true;
		Scoreui.addGameClearBonus();
	    SceneManager.LoadScene("GameOver");
		Debug.Log(wavesCompleted);
	}

    // Update is called once per frame
    void Update()
    {
        if ((SceneManager.GetActiveScene()).name == "GameOver" && Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("StartMenu");
        }

        if ((SceneManager.GetActiveScene()).name == "Main" && Input.GetKeyDown(KeyCode.Escape)) {
            pauseText.SetActive (!pauseText.activeInHierarchy);
            isPaused = isPaused ? false : true;
        }
    }
}
