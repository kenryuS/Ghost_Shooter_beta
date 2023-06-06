using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monstergen : MonoBehaviour
{
    public GameObject monster;
	public GameObject player;
    public static float spawnRate = 1.0f;
    public float spawnLineX = 2.0f;
    public bool isGenerating = true;
    float delta = 0;

	bool isObjInRadius(float px, float py, float r, GameObject obj) {
		 float x = obj.transform.position.x - px;
		 float y = obj.transform.position.y - py;
		 float distance = x*x + y*y;
		 return (r*r) > distance;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManagerScript.isPaused == true) {return;}
        if (this.isGenerating == true) {
            this.delta += Time.fixedDeltaTime;
            if ((this.delta > spawnRate) && spawnRate != 0.0f)
            {
                this.delta = 0;
                float px = Random.Range(this.spawnLineX, 6.5f); 
                float py = Random.Range(-5.0f, 5.0f);
				int trial = 0;
				while (isObjInRadius(px, py, 2.0f, player)) {
					  px = Random.Range(this.spawnLineX, 6.5f);
					  py = Random.Range(-5.0f, 5.0f);
					  trial += 1;
					  if (trial > 5) return;
					  Debug.Log("Monster Didn't Generated");
				}
                GameObject gen = Instantiate(monster) as GameObject;
                gen.transform.position = new Vector3(px, py, 0);
            }
        }
    }
}
