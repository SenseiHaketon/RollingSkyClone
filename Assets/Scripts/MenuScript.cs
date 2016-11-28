using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {

    private GameManager gM;

    public Canvas subMenu;
    public Button btnStart;
    public Button btnQuit;
    public Text titleText;

	// Use this for initialization
	void Start () {

        //subMenu = subMenu.GetComponent<Canvas>();
        //btnStart = btnStart.GetComponent<Button>();
        //btnQuit = btnQuit.GetComponent<Button>();

        subMenu.enabled = false;
        gM = FindObjectOfType<GameManager>();
        if (titleText != null)
        {
            if (gM.lvlWon == 1)
                titleText.text = "You Won!";
            else
                titleText.text = "Game Over!"; 
        }
    }
	
    public void QuitPress()
    {
        subMenu.enabled = true;
        if (btnStart != null)
            btnStart.enabled = false;
        btnQuit.enabled = false;
        if (gM != null)
            gM.levelSpeed = 0;
    }

    public void NoPress()
    {
        subMenu.enabled = false;
        if (btnStart != null)
            btnStart.enabled = true;
        btnQuit.enabled = true;
        if (gM != null)
            gM.levelSpeed = -5f;
    }

    public void PlayPress()
    {
        SceneManager.LoadScene("Level1");
    }

    public void HomePress()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackPress()
    {
        subMenu.enabled = true;
        btnStart.enabled = false;
        btnQuit.enabled = false;
    }
}
