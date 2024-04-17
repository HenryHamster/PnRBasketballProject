using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource AudioSource;
    public AudioClip SandbyAudio;
    public AudioClip CorrectAudio;
    public AudioClip WrongAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init_Audio()
    {
        AudioSource.clip = SandbyAudio;
    }

    public void Play_CorrectAudio()
    {
        AudioSource.clip = CorrectAudio;
        AudioSource.Play();
    }

    public void Player_WrongAudio()
    {
        AudioSource.clip = WrongAudio;
        AudioSource.Play();
    }
}
