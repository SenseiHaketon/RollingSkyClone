using UnityEngine;
using System.Collections;
using Vector3DNamespace;

public class Obstacle01 : MonoBehaviour {

    private GameObject player;
    private CubeCollider playerCollider;
    private bool sfxPlayed;

    public CubeCollider myTrigger;
    public CubeCollider myCollision;

    private AudioSource audioSrc;
    public AudioClip clip;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = player.GetComponent<CubeCollider>();
        sfxPlayed = false;
        audioSrc = this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
        if(myTrigger.myCollider.AABBtoAABB(playerCollider.myCollider))
        {
            if (!sfxPlayed)
                PlayClip();
            if (this.transform.localScale.y < 1)
             this.transform.localScale = new Vector3D(transform.localScale.x, transform.localScale.y + 3 * Time.deltaTime, transform.localScale.z);
        }
	}

    void PlayClip()
    {
        audioSrc.clip = clip;
        audioSrc.Play();
        sfxPlayed = true;
    }
}
