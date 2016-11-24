using UnityEngine;
using System.Collections;
using Vector3DNamespace;

public class FallTile : MonoBehaviour {

    private GameObject player;
    private CubeCollider myCollider;
    public float fallingSpeed = 5f;
    private bool collision;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myCollider = this.GetComponent<CubeCollider>();
        collision = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (myCollider.myCollider.AABBtoAABB(player.GetComponent<CubeCollider>().myCollider))
            collision = true;

        if (collision)
        {
            Vector3D target = new Vector3D(transform.position.x, transform.position.y, transform.position.z);
            target.y = transform.position.y - 1;
            Vector3D temp = new Vector3D(transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3D.Lerp(temp, target, fallingSpeed * Time.deltaTime);
            
        }

        if(transform.position.y == -10)
            Destroy(this.gameObject);
    }

    
}
