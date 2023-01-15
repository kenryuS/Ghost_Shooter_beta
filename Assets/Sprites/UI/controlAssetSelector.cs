using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlAssetSelector : MonoBehaviour
{

    public Dropdown contSele;
    public static int contVal;

    // Start is called before the first frame update
    void Start()
    {
        contSele = gameObject.GetComponent<Dropdown>();
        contVal = 0;
        contSele.onValueChanged.AddListener(delegate {
            dropDownValueChanged(contSele);
        });
    }

    void dropDownValueChanged(Dropdown c)
    {
        contVal = c.value;
    }
}
