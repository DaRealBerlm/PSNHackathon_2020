using UnityEngine;
using TMPro;

public class WelcomeManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput = null;
    [SerializeField] private TextMeshProUGUI errorText = null;

    public void SetName()
    {
        if (string.IsNullOrEmpty(nameInput.text))
        {
            errorText?.SetText("Please enter a name!");
            return;
        }
        DataHandler.instance.SetName(nameInput.text);
    }
}