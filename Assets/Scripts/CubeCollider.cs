using UnityEngine;
using System.Collections;
using System;
using BoxCollider3Dn;
using Vector3DNamespace;

public class CubeCollider : MonoBehaviour {

    private BoxCollider3D myCollider;
    private Renderer myRenderer;
    private Vector3D myCenter;
    private Vector3D myExtents;
    private CubeCollider[] otherObjects;


    // Use this for initialization
    void Start () {
        myRenderer = this.GetComponent<Renderer>();
        myCenter = new Vector3D(myRenderer.bounds.center.x, myRenderer.bounds.center.y, myRenderer.bounds.center.z);
        myExtents = new Vector3D(myRenderer.bounds.extents.x, myRenderer.bounds.extents.y, myRenderer.bounds.extents.z);
        myCollider = new BoxCollider3D(myCenter, myExtents);
        otherObjects = FindObjectsOfType<CubeCollider>();
    }
	
	// Update is called once per frame
	void Update () {
      
            myCollider.Center = new Vector3D(myRenderer.bounds.center.x, myRenderer.bounds.center.y, myRenderer.bounds.center.z);

        foreach (CubeCollider otherObject in otherObjects)
        {
            if (this.tag == "Player" && otherObject.tag != "Player")
            {
                if (this.myCollider.AABBtoAABB(otherObject.myCollider) == true)
                {
                    GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                }
            }
        }

              
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(myCollider.Center, myCollider.Outer * 2);
    }

}
