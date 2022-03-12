using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsAudioController : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip BTNhover;
    public AudioClip BTNclicked;


    public void HoverSound()
    {
        audio.PlayOneShot(BTNhover);
    }

    public void ClickSound()
    {
        audio.PlayOneShot(BTNclicked);
    }
}
