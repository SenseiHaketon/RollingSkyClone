using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip audioClip;

    public void playSFX()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
