using UnityEngine;
using System.Collections;
using Vector3DNamespace;

public class FallTile : MonoBehaviour {

    private GameObject player;
    private CubeCollider myCollider;
    private bool collision;
    private bool sfxPlayed;

    public float fallingSpeed = 5f;

    private AudioSource audioSrc;
    public AudioClip clip;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myCollider = this.GetComponent<CubeCollider>();
        collision = false;
        sfxPlayed = false;
        audioSrc = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myCollider.myCollider.AABBtoAABB(player.GetComponent<CubeCollider>().myCollider))
            collision = true;

        if (collision)
        {
            if(!sfxPlayed)
                PlayClip();
            Vector3D target = new Vector3D(transform.position.x, transform.position.y, transform.position.z);
            target.y = transform.position.y - 1;
            Vector3D temp = new Vector3D(transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3D.Lerp(temp, target, fallingSpeed * Time.deltaTime);     
        }

        if(transform.position.y == -10)
            Destroy(this.gameObject);
    }

    void PlayClip()
    {
        audioSrc.clip = clip;
        audioSrc.Play();
        sfxPlayed = true;
    }

    
}
