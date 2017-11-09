using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    /*
  TODO:

*/

    int mainLevel = 1;

    public GameObject creditsMenu;

    private void Awake()
    {
        creditsMenu.SetActive(false);
    }
    
    public void loadMainLevel()
    {
        SceneManager.LoadScene(mainLevel);
    }
    public void toggleCreditsMenu()
    {
        creditsMenu.SetActive(!creditsMenu.activeSelf);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
