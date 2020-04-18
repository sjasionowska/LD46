using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip hoverClip;
    public AudioClip clickClip;

    public void PlayHover()
    {
        source.PlayOneShot(hoverClip);
    }

    public void PlayClick()
    {
        source.PlayOneShot(clickClip);
    }

}
