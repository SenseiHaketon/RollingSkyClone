using UnityEngine;
using System.Collections;
using Vector3DNamespace;

public class LevelMovement : MonoBehaviour {

    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        // this.transform.position = new Vector3D(0, 0, 1 * levelSpeed * Time.time);
        if (gameManager.counter <= 0)
            this.transform.position = new Vector3D(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1 * gameManager.levelSpeed * Time.deltaTime);
        else
            gameManager.counter -= Time.deltaTime;
    }
}
