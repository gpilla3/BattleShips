using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//Used to store information about the user such as how many questions they got correct
public class GameData : Singleton<GameData>
{
    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
    }

    //Saves the data onto the database
    IEnumerator SavePlayerData()
    {
        if(DBManager.username != null)
        {
            WWWForm form = new WWWForm();

            form.AddField("name", DBManager.username);
            form.AddField("score", DBManager.userScore);

            WWW www = new WWW("http://localhost/sqlconnect/savedata.php", form); //Connecting to the database

            yield return www;
            //Checks if the game was saved correctly
            if (www.text == "0")
            {
                Debug.Log("Game Saved.");
            }
            else
            {
                Debug.Log("Save Failed. Error #" + www.text);
            }
        }
        SceneManager.LoadScene(4);
    }

    //Used to increase the score for the player
    public void IncreaseScore()
    {
        CallSaveData();
    }
}
