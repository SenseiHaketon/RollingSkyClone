using UnityEngine;
using System.Collections;
using Vector3DNamespace;

public class Stamp : MonoBehaviour {

    public CubeCollider playerCollider;
    public CubeCollider myTrigger;
    public float speed = 5f;

    private Vector3D myPos;
    private Vector3D targetPos;

    private AudioSource audioSrc;
    public AudioClip clip;
    private bool sfxPlayed;

    // Use this for initialization
    void Start () {

        myPos = new Vector3D(transform.position.x, transform.position.y, transform.position.z);
        targetPos = new Vector3D(transform.position.x, 0.5f, transform.position.z);
        sfxPlayed = false;
        audioSrc = this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (myTrigger.myCollider.AABBtoAABB(playerCollider.myCollider))
        {
            myPos = new Vector3D(transform.position.x, transform.position.y, transform.position.z);
            targetPos = new Vector3D(transform.position.x, 0.5f, transform.position.z);
            Triggered();
            if (!sfxPlayed)
                PlayClip();
        }
    }

    void Triggered()
    {
        transform.position = Vector3D.Lerp(myPos, targetPos, speed);
    }

    void PlayClip()
    {
        audioSrc.clip = clip;
        audioSrc.Play();
        sfxPlayed = true;
    }
}
