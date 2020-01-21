using UnityEngine;
using UnityEngine.SceneManagement;

//Used to manage the database menu
public class Database : MonoBehaviour
{
    //Loads the Register Scene
    public void GoToRegister()
    {
        SceneManager.LoadScene(2);
    }

    //Loads the Login Scene
    public void GoToLogin()
    {
        SceneManager.LoadScene(1);
    }

    //Loads the menu scene without loging anyone in
    public void OfflineGame()
    {
        SceneManager.LoadScene(4);
    }

    //If the exit button gets clicked
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
