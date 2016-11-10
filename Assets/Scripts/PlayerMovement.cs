using UnityEngine;
using System.Collections;
using Vector3DNamespace;

public class PlayerMovement : MonoBehaviour {

    public float spaceToCam = 5f;
    public float speed = 0.1f;
    public float speedKeyboard = 0.1f;


    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frameCamera.main.ScreenToWorldPoint(temp)
    void Update () {


        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10));

            Vector3 target = transform.position;
            target.z = touchPosition.z;
            transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
        }
        else if(Input.GetKey("a"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speedKeyboard * Time.deltaTime);
        }
        else if (Input.GetKey("d"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speedKeyboard * Time.deltaTime);
        }
    }
}
