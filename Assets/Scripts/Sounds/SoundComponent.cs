using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundComponent : MonoBehaviour
{
    private static SoundComponent _instance;
    public static SoundComponent Instance { get { return _instance; } }


    private AudioSource _myAudioSource;


    public AudioClip _chestOpening;
    public AudioClip _itemRecolectable;
    public AudioClip _checkPoint;


    public void PlaySound(AudioClip myAudio)
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
