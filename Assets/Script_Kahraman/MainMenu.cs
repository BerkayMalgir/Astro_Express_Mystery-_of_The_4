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
    public GameObject cutScene1;
    public GameObject cutScene2;
    public GameObject cutScene3;
    public GameObject cutScene4;
    public GameObject cutScene5;
    public GameObject cutScene6;
    public GameObject cutScene7;
    public GameObject cutScene8;
    public GameObject cutScene9;

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
    public void nextScene()
    {
        mainMenu.SetActive(false);
        cutScene1.SetActive(true);
    }
    public void nextScene2()
    {
        cutScene1.SetActive(false);
        cutScene2.SetActive(true);
    }
    public void nextScene3()
    {
        cutScene2.SetActive(false);
        cutScene3.SetActive(true);
    }
    public void nextScene4()
    {
        cutScene3.SetActive(false);
        cutScene4.SetActive(true);
    }
    public void nextScene5()
    {
        cutScene4.SetActive(false);
        cutScene5.SetActive(true);
    }
    public void nextScene6()
    {
        cutScene5.SetActive(false);
        cutScene6.SetActive(true);
    }
    public void nextScene7()
    {
        cutScene6.SetActive(false);
        cutScene7.SetActive(true);
    }
    public void nextScene8()
    {
        cutScene7.SetActive(false);
        cutScene8.SetActive(true);
    }
    public void nextScene9()
    {
        cutScene8.SetActive(false);
        cutScene9.SetActive(true);
    }
    public void lastScene()
    {
        cutScene9.SetActive(false);
    }
}