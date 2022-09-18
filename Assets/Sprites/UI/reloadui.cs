using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reloadui : MonoBehaviour
{
    float firerate;
    GameObject reloadGauge;
    GameObject shooting;
    public Image gauge;
    bool updateUi = false;
    int updateCounter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        this.shooting = GameObject.Find("player");
        this.firerate = this.shooting.GetComponent<Shooting>().fireRate;
        if (this.firerate < 0.6f) gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Z) && this.updateUi == false) {
            this.updateUi = true;
            uiUpdate();
            this.updateCounter += 1;
            if (this.updateCounter == 50) {
                this.updateUi = false;
                this.gauge.fillAmount = 1.0f;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.R)) {
            this.gauge.fillAmount = 1.0f;
            Debug.Log("Reseted");
        }
    }
    
    void uiUpdate()
    {
        this.gauge.fillAmount -= 0.02f;
    }
}
