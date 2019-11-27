using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

//Used to log the player in to the database
public class Login : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public Button loginButton;
    public TextMeshProUGUI errorDisplayL;

    //Goes back to the database scene
    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    //Logs the player into the database
    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", usernameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW("http://localhost/sqlconnect/login.php", form); //Connecting to the database

        yield return www;

        //Checks if the user was logged in successfully or not
        if (www.text[0] == '0')
        {
            Debug.Log("User logged in successfully");
            DBManager.username = usernameField.text;
            DBManager.userScore = int.Parse(www.text.Split('\t')[1]);
            SceneManager.LoadScene(4);
        }
        else
        {
            errorDisplayL.color = new Color(1, 0, 0, 1);
            errorDisplayL.SetText("User login failed. " + www.text);
            Debug.Log("User login failed. " + www.text);
        }
    }

    //Used to verify if the inputs are valid
    public void VerifyInputs()
    {
        loginButton.interactable = (usernameField.text.Length >= 4 && passwordField.text.Length >= 6);
    }
}
