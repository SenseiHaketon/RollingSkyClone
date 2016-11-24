using UnityEngine;
using System.Collections;
using Vector3DNamespace;

public class Obstacle01 : MonoBehaviour {

    private GameObject player;
    private CubeCollider playerCollider;
    public CubeCollider myTrigger;
    public CubeCollider myCollision;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = player.GetComponent<CubeCollider>();
	}
	
	// Update is called once per frame
	void Update () {
	
        if(myTrigger.myCollider.AABBtoAABB(playerCollider.myCollider))
        {
            if(this.transform.localScale.y < 1)
             this.transform.localScale = new Vector3D(transform.localScale.x, transform.localScale.y + 3 * Time.deltaTime, transform.localScale.z);
        }
	}
}
