using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource src;

    public void PlayAudio()
    {
        src.PlayOneShot(clip);
    }
}
