using UnityEngine;
using System.Collections;
using Vector3DNamespace;

public class PlayerMovement : MonoBehaviour {

    public float spaceToCam = 5f;
    public float speed = 0.1f;
    public float speedKeyboard = 0.1f;
    public float jumpSpeed = 1.0f;
    private float fallingSpeed = 15f;
    public float fallingSpeedCtrl = 15f;
    public float hopHeight = 5f;

    private bool inAir;
    private CubeCollider myCubeCollider;


    // Use this for initialization
    void Start () {
        inAir = true;
        myCubeCollider = this.GetComponent<CubeCollider>();
        
    }

    // Update is called once per frameCamera.main.ScreenToWorldPoint(temp)
    void Update () {


        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        //{
        //    Vector3D temp = new Vector3D(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10);
        //    Vector3D touchPosition = Camera.main.ScreenToWorldPoint(temp);

        //    Vector3 target = transform.position;
        //    target.z = touchPosition.z;
        //    transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
        //}
        //else 
        if (Input.GetKey("a"))
        {
            transform.position = new Vector3D(transform.position.x, transform.position.y, transform.position.z - speedKeyboard * Time.deltaTime);
        }
        else if (Input.GetKey("d"))
        {
            transform.position = new Vector3D(transform.position.x, transform.position.y, transform.position.z + speedKeyboard * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.Space) && inAir == false)
        {
            StartCoroutine(Hop(0.75f));
        }

        if(myCubeCollider.CheckGround())
        {
            inAir = false;
        }
        else if (myCubeCollider.CheckGround() == false)
        {
            Vector3D target = new Vector3D(transform.position.x, transform.position.y, transform.position.z);
            target.y = transform.position.y - 1;
            Vector3D temp = new Vector3D(transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3D.Lerp(temp, target, fallingSpeed * Time.deltaTime);
            inAir = true;
        }

        if (inAir == false)
        {
            fallingSpeed = 0f;
        }

        if (inAir == true)
        {
            fallingSpeed = fallingSpeedCtrl;
        }
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.2f);
        inAir = true;
    }

    IEnumerator Hop(float time)
    {
        if (inAir) yield break;

        Vector3D target = new Vector3D(transform.position.x, transform.position.y - 0.1f, transform.position.z);
        inAir = true;
        Vector3D startPos = new Vector3D(transform.position.x, transform.position.y, transform.position.z);
        float timer = 0.0f;

        while (timer <= 1.0f)
        {
            float height = Mathf.Sin(Mathf.PI * timer) * hopHeight;
            transform.position = Vector3D.Lerp(startPos, target, timer) + Vector3D.up * height;

            timer += Time.deltaTime / time;
            yield return null;
        }
        inAir = false;
    }



}
