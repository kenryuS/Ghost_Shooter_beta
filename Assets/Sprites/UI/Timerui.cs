using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timerui : MonoBehaviour
{
    GameObject uitimer;
    float delta;
    float span = 1.0f;
    public static int time = 0;

	void DeleteAllEnemy() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Monster");
		GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("enemyBullet");
		foreach (GameObject enemy in enemies) {
			GameObject.Destroy(enemy);
		}
		foreach (GameObject enemyBullet in enemyBullets) {
			GameObject.Destroy(enemyBullet);
		}
	}

    // Start is called before the first frame update
    void Start()
    {
		time = gameManagerScript.secPerWave;
        this.uitimer = GameObject.Find("Timer");
        this.uitimer.GetComponent<Text>().text = "Time: 0s";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManagerScript.isPaused == true) {return;}
        this.delta += Time.fixedDeltaTime;
        if (this.delta > this.span && time > 0) {
            this.delta = 0;
            time -= 1;
            this.uitimer.GetComponent<Text>().text = "Time: " + time.ToString() + "s";
        }
		else if (time == 0) {
			 gameManagerScript.wavesCompleted += 1;
			 Scoreui.addWaveBonus();
			 if (gameManagerScript.wavesCompleted == gameManagerScript.waveNumber) gameManagerScript.gameCompleted();
			 DeleteAllEnemy();
			 time = gameManagerScript.secPerWave;
		}
    }
}
