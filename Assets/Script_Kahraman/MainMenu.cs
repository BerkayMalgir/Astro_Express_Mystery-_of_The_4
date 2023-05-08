using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject inmainMenu;
    public GameObject settingsMenu;
    public GameObject pauseMenu;
    private bool _isPlay;
    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void menu()
    {
        mainMenu.SetActive(false);
        _isPlay = true;
    }
    public void settings()
    {
        inmainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void back()
    {
        if (!_isPlay)
        {
            inmainMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }
        else {
            pauseMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }
    }
    public void quitGame()
    {
        Application.Quit();
    }

}