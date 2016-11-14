using UnityEngine;
using System.Collections;
using Vector3DNamespace;

public class LevelMovement : MonoBehaviour {

    public float levelSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        this.transform.position = new Vector3D(1 * levelSpeed * Time.time, 0, 0);
	}
}
