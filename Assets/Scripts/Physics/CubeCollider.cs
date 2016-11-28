using UnityEngine;
using System.Collections;
using System;
using BoxCollider3Dn;
using Vector3DNamespace;

public class CubeCollider : MonoBehaviour {

    public BoxCollider3D myCollider;
    private Renderer myRenderer;
    private Vector3D myCenter;
    private Vector3D myExtents;
    private GameManager gameManager;


    // Use this for initialization
    void Start () {
        myRenderer = this.GetComponent<Renderer>();
        myCenter = new Vector3D(myRenderer.bounds.center.x, myRenderer.bounds.center.y, myRenderer.bounds.center.z);
        myExtents = new Vector3D(myRenderer.bounds.extents.x, myRenderer.bounds.extents.y, myRenderer.bounds.extents.z);
        myCollider = new BoxCollider3D(myCenter, myExtents);
        gameManager = FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
      
            // Update Center
            myCollider.Center = new Vector3D(myRenderer.bounds.center.x, myRenderer.bounds.center.y, myRenderer.bounds.center.z);        
	}

    // Draw Collision Box
    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(myCollider.Center, myCollider.Outer * 2);
    //}

    // Check collision with Ground function
    public bool CheckGround()
    {
        bool temp = false;
        foreach(CubeCollider otherObject in gameManager.otherObjects)
        {
            if (otherObject != null)
            {
                if (this.myCollider.AABBtoAABB(otherObject.myCollider) == true && otherObject.tag == "Ground")
                {
                    temp = true;
                    return temp;
                }
                else
                {
                    continue;
                } 
            }
        }
        return false;
    }

}
