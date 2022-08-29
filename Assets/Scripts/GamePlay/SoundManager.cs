using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public AudioSource source;
    public static SoundManager instance;
    public AudioClip[] clip;
    public Sprite mute, unmute;
    public Image musicImage;

    void Awake(){
        instance = this;
        LoadMusic();
    }

    void Start()
    {
        source.clip = clip[0];
        source.Play();
        source.loop = true;
    }

    public void ChangeMusicMode(){
        switch(PlayerPrefs.GetInt("music")){
            case 0:
                PlayerPrefs.SetInt("music", 1);
                break;
            case 1:
                PlayerPrefs.SetInt("music", 0);
                break;   
        }
        LoadMusic();
    }

    public void LoadMusic(){
        switch(PlayerPrefs.GetInt("music")){
            case 0:
                MusicPlayer.instance.StartAudio();
                musicImage.sprite = unmute;
                source.volume = 1;
                break;
            case 1:
                MusicPlayer.instance.StopAudio();
                musicImage.sprite = mute;
                source.volume = 0;
                break; 
        }
    }
}
