using UnityEngine;
using System.Collections;

public class GemScript : MonoBehaviour {

    private CubeCollider player;
    private CubeCollider myCollider;
    private GameManager gM;

    public int points = 50;

    private bool sfxPlayed;
    public AudioSource audioSrc;
    public AudioClip clip;

    // Use this for initialization
    void Start () {

        myCollider = this.GetComponent<CubeCollider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CubeCollider>();
        gM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        sfxPlayed = false;
    }
	
	// Update is called once per frame
	void Update () {
	
        if(myCollider.myCollider.AABBtoAABB(player.myCollider))
        {
            if (!sfxPlayed)
            {
                PlayClip();
                gM.Score += points;
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
