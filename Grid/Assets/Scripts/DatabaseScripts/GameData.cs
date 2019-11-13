using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : Singleton<GameData>
{
    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();

        form.AddField("name", DBManager.username);
        //DBManager.userScore = GameManager.Instance.correctAnswer;
        form.AddField("score", DBManager.userScore);

        WWW www = new WWW("http://localhost/sqlconnect/savedata.php", form);
        yield return www;
        if(www.text == "0")
        {
            Debug.Log("Game Saved.");
        }
        else
        {
            Debug.Log("Save Failed. Error #" + www.text);
        }
        //DBManager.Logout();
        SceneManager.LoadScene(4);
    }

    public void IncreaseScore()
    {
        //DBManager.userScore += 17;
        CallSaveData();
    }
}
