using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Registration : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public Button submitButton;

    //Goes back to the database scene
    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", emailField.text);
        form.AddField("name", usernameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);

        yield return www;
        if(www.text == "0")
        {
            Debug.Log("User created successfully");
            SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User creation failed. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (usernameField.text.Length >= 4 && passwordField.text.Length >= 6 && emailField.text.Length >=6);
    }

}
