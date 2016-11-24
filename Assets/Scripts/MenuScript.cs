using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas subMenu;
    public Button btnStart;
    public Button btnQuit;

	// Use this for initialization
	void Start () {

        subMenu = subMenu.GetComponent<Canvas>();
        btnStart = btnStart.GetComponent<Button>();
        btnQuit = btnQuit.GetComponent<Button>();

        subMenu.enabled = false;
    }
	
    public void QuitPress()
    {
        subMenu.enabled = true;
        btnStart.enabled = false;
        btnQuit.enabled = false;
    }

    public void NoPress()
    {
        subMenu.enabled = false;
        btnStart.enabled = true;
        btnQuit.enabled = true;
    }

    public void PlayPress()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
