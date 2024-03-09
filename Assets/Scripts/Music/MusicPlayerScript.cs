using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ObjectMusic;
    private AudioSource AudioSource;

    public Slider volumeSlider;

    private float MusicVolume = 1f;
    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("IntroMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();
        MusicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = MusicVolume;
        volumeSlider.value = MusicVolume;

    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("volume", MusicVolume);
    }

    public void updateVolume( float volume)
    {
        MusicVolume = volume;
    }
}
