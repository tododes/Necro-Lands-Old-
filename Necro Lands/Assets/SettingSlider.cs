using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingSlider : MonoBehaviour {

    private Slider slide;
    public SoundType sound;
    public enum SoundType
    {
        MUSIC, SFX
    }
	// Use this for initialization
	void Start ()
    {
        slide = GetComponent<Slider>();
        slide.maxValue = 1;
        slide.minValue = 0;
        if (sound == SoundType.MUSIC)
            slide.value = PlayerPrefs.GetFloat("Music");
        else
            slide.value = PlayerPrefs.GetFloat("SFX");
	}

    public void SetValue()
    {
       if(sound == SoundType.MUSIC)
            PlayerPrefs.SetFloat("Music", slide.value);
       else
            PlayerPrefs.SetFloat("SFX", slide.value);
    }
}
