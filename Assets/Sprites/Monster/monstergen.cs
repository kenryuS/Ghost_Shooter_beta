using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monstergen : MonoBehaviour
{
    public GameObject monster;
    float spawnRate = 1.0f;
    public float spawnLineX = 2.0f;
    public bool isGenerating = true;
    float delta = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.isGenerating == true) {
            this.delta += Time.fixedDeltaTime;
            if ((this.delta > this.spawnRate) && this.spawnRate != 0.0f)
            {
                this.delta = 0;
                GameObject gen = Instantiate(monster) as GameObject;
                float px = Random.Range(this.spawnLineX, 6.5f);
                float py = Random.Range(-5.0f, 5.0f);
                gen.transform.position = new Vector3(px, py, 0);
            }
        }
    }
}
