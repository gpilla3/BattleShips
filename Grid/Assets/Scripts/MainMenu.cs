using UnityEngine;
using UnityEngine.SceneManagement;

//This is used to manage the main menu
public class MainMenu : MonoBehaviour
{
    public TMPro.TextMeshProUGUI playerName;

    private void Start()
    {
        if (DBManager.LoggedIn)
        {
            playerName.SetText("Welcome " + DBManager.username);
        }
    }

    //Loads the next scene once start is clicked
    public void StartGame()
    {
        SceneManager.LoadScene(5);
    }

    public void playerInfo()
    {
        SceneManager.LoadScene(3);
    }

    //If the exit button gets clicked
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
