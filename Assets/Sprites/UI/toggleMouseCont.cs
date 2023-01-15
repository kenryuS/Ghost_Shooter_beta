using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleMouseCont : MonoBehaviour
{
    public Toggle mouseContTog;
    public static bool mctVal;
    // Start is called before the first frame update
    void Start()
    {
        mouseContTog = gameObject.GetComponent<Toggle>();
        mctVal = false;
        mouseContTog.onValueChanged.AddListener(delegate {
            ToggleOnValueChanged(mouseContTog);
        });
    }

    // Update is called once per frame
    void ToggleOnValueChanged(Toggle change)
    {
        mctVal = change.isOn;
    }
}
