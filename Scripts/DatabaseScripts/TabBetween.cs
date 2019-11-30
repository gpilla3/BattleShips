using TMPro;
using UnityEngine;

public class TabBetween : MonoBehaviour
{
    public TMP_InputField nextField;
    TMP_InputField myField;

    // Start is called before the first frame update
    void Start()
    {
        if(nextField == null)
        {
            Destroy(this);
        }
        myField = GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myField.isFocused && Input.GetKeyDown(KeyCode.Tab))
        {
            nextField.ActivateInputField();
        }
    }
}
