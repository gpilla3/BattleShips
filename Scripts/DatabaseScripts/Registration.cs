using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

//Registration class that is used to register a user onto the database
public class Registration : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public Button submitButton;
    public TextMeshProUGUI errorDisplayR;

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

        WWW www = new WWW("http://localhost/sqlconnect/register.php", form); //Connecting to he database

        yield return www;

        //Checks if the user was logged in successfully or not
        if (www.text == "0")
        {
            Debug.Log("User created successfully");
            SceneManager.LoadScene(0);
        }
        else
        {
            errorDisplayR.color = new Color(1,0,0,1);
            errorDisplayR.SetText("User creation failed. " + www.text);
            Debug.Log("User creation failed. " + www.text);
        }
    }

    //Verify if the input entered in is valid
    public void VerifyInputs()
    {
        submitButton.interactable = (usernameField.text.Length >= 4 && passwordField.text.Length >= 6 && emailField.text.Length >=6);
    }

}
