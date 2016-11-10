using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float spaceToCam = 5f;
    public float speed = 0.1f;


    // Use this for initialization
    void Start () {

    }

    // Update is called once per frameCamera.main.ScreenToWorldPoint(temp)
    void Update () {

        Vector3 temp = Input.mousePosition;
        temp.z = spaceToCam;
        Vector3 temp2 = Camera.main.ScreenToWorldPoint(temp);

        this.transform.Translate(0, 0, temp2.z * speed * Time.deltaTime);
	}
}
