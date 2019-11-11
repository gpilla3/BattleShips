using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", usernameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);

        yield return www;
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

    public void VerifyInputs()
    {
        loginButton.interactable = (usernameField.text.Length >= 4 && passwordField.text.Length >= 6);
    }
}
