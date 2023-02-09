using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponselect : MonoBehaviour
{
    public Dropdown wsele;
    public static int wval;

    void Start() {
        wsele = gameObject.GetComponent<Dropdown>();
        wval = 0;
        wsele.onValueChanged.AddListener(delegate {
            DropdownValueChanged(wsele);
        });
    }

    void DropdownValueChanged(Dropdown c) {
        wval = c.value;
    }
}
