using UnityEngine;
using System.Collections;

public class ButtonClickSound : MonoBehaviour {

    public AudioSource audioSrc;
    public AudioClip clip;

    public void PlayClip()
    {
        audioSrc.clip = clip;
        audioSrc.Play();
    }
}
