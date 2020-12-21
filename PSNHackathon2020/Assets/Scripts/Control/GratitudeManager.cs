using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GratitudeManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField input = null;
    [SerializeField] private TextMeshProUGUI errorLabel = null;
    bool errorIsRunning = false;

    public void AddGratitude()
    {
        if (string.IsNullOrEmpty(input.text))
        {
            if (errorIsRunning) return;
            StartCoroutine(SetError("Please enter a thing you are grateful for!"));
            return;
        }
        DataHandler.instance.AddGratitude(input.text);
        input.text = "";
    }

    public void BackToHome()
    {
        SceneManager.LoadScene(1);
    }

    private IEnumerator SetError(string err)
    {
        errorIsRunning = true;
        errorLabel?.SetText(err);
        yield return new WaitForSeconds(2f);
        errorLabel?.SetText("");
        errorIsRunning = false;
    }
}
