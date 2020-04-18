using System;
using UnityEngine;

[Serializable]
public class Sound
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private AudioClip _clip;
    [SerializeField,Range(0f, 1f)]
    private float _volume;
    [SerializeField,Range(.1f, 3f)]
    private float _pitch;

    public string Name { get { return _name; } set { _name = value; } }
    public AudioClip Clip { get { return _clip; } set { _clip = value; } }
    public float Volume { get { return _volume; } set { _volume = value; } }
    public float Pitch { get { return _pitch; } set { _pitch = value; } }
}
