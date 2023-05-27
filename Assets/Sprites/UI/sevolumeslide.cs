using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sevolumeslide : MonoBehaviour
{

    public Slider seVolumeSlide;
    public static float seVolume;
    // Start is called before the first frame update
    void Start()
    {
        seVolume = 0.5f;
        ValueChanged(this.seVolumeSlide);
        seVolumeSlide.onValueChanged.AddListener(delegate {
            ValueChanged(this.seVolumeSlide);
        });
    }

    void ValueChanged(Slider v)
    {
        seVolume = v.value;
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = seVolume;
        audio.Play();
    }
}
