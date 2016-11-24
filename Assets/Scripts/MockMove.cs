using UnityEngine;
using System.Collections;
using Vector3DNamespace;

public class MockMove : MonoBehaviour {

    public float speed = 10f;

    private GameManager gM;
    private Vector3D myPos;

    // Use this for initialization
    void Start () {
        gM = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (gM.counter <= 0)
        {
            myPos = new Vector3D(transform.position.x, transform.position.y, transform.position.z);
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector3D temp = new Vector3D(Camera.main.ScreenToWorldPoint(new Vector3D(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5)).x,
                                             Camera.main.ScreenToWorldPoint(new Vector3D(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5)).y,
                                             Camera.main.ScreenToWorldPoint(new Vector3D(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5)).z);
                myPos = new Vector3D(transform.position.x, transform.position.y, transform.position.z);

                transform.position = Vector3D.Lerp(myPos, new Vector3D(temp.x, transform.position.y, transform.position.z), speed);
            }
        }
    }
}
