using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public float levelSpeed = -5f;
    public float counter = 5f;

    public CubeCollider[] otherObjects;

    private GameObject player;

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        otherObjects = FindObjectsOfType<CubeCollider>();

        foreach(CubeCollider otherObject in otherObjects)
        {
            if (otherObject.transform.position.z <= player.transform.position.z - 10)
                Destroy(otherObject.gameObject);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOverMenu");
    }
}
