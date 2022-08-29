using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{

    public static MusicPlayer instance;
    int currentSong = 0;
    AudioSource audioSource;
    public AudioClip[] clipNames;
    public Text musicName;
    public Slider musicLength;
    private bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        StartAudio();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(!stop) 
        {
            musicLength.value += Time.deltaTime;
            if(musicLength.value >= audioSource.clip.length)
            {
                currentSong++;
                if(currentSong >= clipNames.Length){
                    currentSong = 0;
                    StartAudio();
                }
            }
        }
    }

    public void StartAudio(int changeMusic = 0)
    {
        currentSong += changeMusic;
        if(currentSong >= clipNames.Length)
        {
            currentSong = 0;
        }
        else if(currentSong < 0)
        {
            currentSong = clipNames.Length - 1;
        }

        if(audioSource.isPlaying && changeMusic == 0)
        {
            return;
        }

        if(stop)
        {
            stop = false;
        }
        audioSource.clip = clipNames[currentSong];
        musicName.text = audioSource.clip.name;
        musicLength.maxValue = audioSource.clip.length;
        musicLength.value = 0;
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
        stop = true;
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
