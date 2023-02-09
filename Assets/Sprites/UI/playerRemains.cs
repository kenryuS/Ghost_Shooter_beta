using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerRemains : MonoBehaviour
{
    GameObject uiRemains;
    public static int remains = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.uiRemains = GameObject.Find("playerRemain");
        this.uiRemains.GetComponent<Text>().text = string.Format("Player: {0:d}",remains);
    }

    public void updateui()
    {
        remains -= 1;
        this.uiRemains.GetComponent<Text>().text = string.Format("Player: {0:d}",remains);
    }

    public void updateValue()
    {
        this.uiRemains.GetComponent<Text>().text = string.Format("Player: {0:d}",remains);
    }
}
