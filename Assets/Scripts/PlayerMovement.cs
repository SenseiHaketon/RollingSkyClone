﻿using UnityEngine;
using System.Collections;
using Vector3DNamespace;

public class PlayerMovement : MonoBehaviour {

    public float speed = 0.1f;
    public float speedKeyboard = 0.1f;
    public float fallingSpeedCtrl = 15f;
    public float hopHeight = 5f;
    public bool inAir;
    public bool goJump = false;

    private float fallingSpeed = 15f;
    private GameManager gameManager;
    private CubeCollider myCubeCollider;
    private Vector3D myPos;

    public MockMove mockObject;
    private Vector3D mockPos;

    // Use this for initialization
    void Start () {
        inAir = true;
        myCubeCollider = this.GetComponent<CubeCollider>();
        gameManager = FindObjectOfType<GameManager>();
        goJump = false;
        myPos = new Vector3D(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update () {

        // Follow mockobject controlled by touch
        myPos = new Vector3D(transform.position.x, transform.position.y, transform.position.z);
        mockPos = new Vector3D(mockObject.transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3D.Lerp(myPos, mockPos, speed);

        // Keyboard input
        if (gameManager.counter <= 0)
        {
            if (Input.GetKey("a"))
            {
                transform.position = new Vector3D(transform.position.x - speedKeyboard * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else if (Input.GetKey("d"))
            {
                transform.position = new Vector3D(transform.position.x + speedKeyboard * Time.deltaTime, transform.position.y, transform.position.z);
            }

            //if (Input.GetKey(KeyCode.Space) && inAir == false)
            //{
            //    StartCoroutine(Hop(0.75f));
            //}
        }

        // Check collision with "hostile" objects
        foreach (CubeCollider otherObject in gameManager.otherObjects)
        {
            if (otherObject.tag == "Collision")
            {
                if (this.myCubeCollider.myCollider.AABBtoAABB(otherObject.myCollider) == true)
                {
                    gameManager.GameOver();
                }
            }
        }
        
        // If collision with JumpTile
        if (goJump)
        {
            StartCoroutine(Hop(0.75f));
            goJump = false;
        }

        // Check collision with ground
        if (myCubeCollider.CheckGround())
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
        else if (inAir == true)
        {
            fallingSpeed = fallingSpeedCtrl;
        }
    }

    // Jump 
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
