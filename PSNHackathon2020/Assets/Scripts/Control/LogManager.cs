using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;

public class LogManager : MonoBehaviour
{
    [SerializeField] private Transform logTemplate = null;
    [SerializeField] private TextMeshProUGUI errorLabel = null;

    private void Awake()
    {
        if (DataHandler.instance.dataFrame.logs == null || DataHandler.instance.dataFrame.logs.Count == 0)
        {
            errorLabel.SetText("You do not have any logs!\nPlease finish some activities to view them");
            return;
        }

        foreach (KeyValuePair<DateTime, Log> entry in DataHandler.instance.dataFrame.logs)
        {
            SpawnLog(entry.Key, entry.Value);
        }    
    }

    public void BackToHome()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    private void SpawnLog(DateTime time, Log log)
    {
        Transform instantiated = Instantiate(logTemplate, transform);
        instantiated.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(DateConvert.DateToWords(time, false));
        instantiated.GetComponent<LogVisual>().Initialize(time, log);
    }
}
