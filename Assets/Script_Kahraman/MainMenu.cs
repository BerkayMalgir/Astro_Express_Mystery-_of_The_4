using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject inmainMenu;
    public GameObject settingsMenu;

    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void menu()
    {
        mainMenu.SetActive(false);
    }
    public void settings()
    {
        inmainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    
    public void back()
    {
        inmainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
    public void quitGame()
    {
        Application.Quit();
    }

}