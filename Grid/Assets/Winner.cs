using UnityEngine;

//Used to display information about the user once a winner has been found
public class Winner : MonoBehaviour
{
    public TMPro.TextMeshProUGUI winnerText;

    // Update is called once per frame
    void Update()
    {
        if(winnerText != null)
        {
            winnerText.SetText("Your overall Questions Answered has increased to " + DBManager.userScore);
        }
    }
}
