using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicComponent : MonoBehaviour
{
    private static MusicComponent _instance;
    public static MusicComponent Instance { get { return _instance; } }


    private AudioSource _myAudioSource;


    public AudioClip _OST1;
    public AudioClip _OST2;
    public AudioClip _OST3;


    public void PlayMusic(AudioClip myAudio)
    {
        _myAudioSource.PlayOneShot(myAudio);
    }

    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
