using UnityEngine;
using System.Collections;

public class SlowPU : MonoBehaviour {

    private CubeCollider player;
    private CubeCollider myCollider;
    private GameManager gM;

    private bool sfxPlayed;
    public AudioSource audioSrc;
    public AudioClip clip;

    private int points = 100;

    // Use this for initialization
    void Start()
    {

        myCollider = this.GetComponent<CubeCollider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CubeCollider>();
        gM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        sfxPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (myCollider.myCollider.AABBtoAABB(player.myCollider))
        {
            if (!sfxPlayed)
            {
                gM.Score += points;
                PlayClip();
                gM.activePU = "slow";
                this.gameObject.SetActive(false);
            }

        }
    }

    void PlayClip()
    {
        audioSrc.clip = clip;
        audioSrc.Play();
        sfxPlayed = true;
    }
}
