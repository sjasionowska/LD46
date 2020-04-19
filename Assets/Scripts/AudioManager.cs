using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;
    public AudioMixer AudioMixer;
    public AudioMixerGroup group;
    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new AudioManager();

            return _instance;
        }
    }

    private AudioManager() { }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        foreach(var s in Sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;
            s.Source.volume = s.Volume;
            s.Source.loop = s.Loop;
            s.Source.outputAudioMixerGroup = group;
            s.Source.playOnAwake = false;
        }
    }

    public void SetVolume(float volume)
    {
        Debug.Log(Mathf.Log10(volume) * 20);
        AudioMixer.SetFloat("MainVolume", Mathf.Log10(volume) * 20);
    }

    void Start()
    {
        Play("MainTheme");
    }

    public void Play(string name)
    {
        var sound = Array.Find(Sounds, s => s.Name == name);
        sound.Source.Play();
    }
}
