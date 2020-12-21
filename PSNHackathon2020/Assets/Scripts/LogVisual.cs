using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogVisual : MonoBehaviour
{
    private Log log;
    private DateTime time;

    public void Initialize(DateTime time, Log log)
    {
        this.time = time;
        this.log = log;

        GetComponent<Button>().onClick.AddListener(ShowLog);
    }

    private void ShowLog()
    {
        print("Clicked");
        Transform canvas = transform.parent.parent.parent.parent;
        Transform toInstantiate = Resources.Load<Transform>("logTemplate");

        Transform instantiated = Instantiate(toInstantiate, canvas);
        instantiated.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(instantiated.gameObject);
        });

        instantiated.GetChild(1).GetComponent<TextMeshProUGUI>().SetText(DateConvert.DateToWords(time, true));

        var gText = instantiated.GetChild(2).GetComponent<TextMeshProUGUI>();
        if (log.gratitude != null && log.gratitude.Count != 0) gText.SetText($"I was grateful for {string.Join(", ", log.gratitude)}");
        else gText.SetText($"No entries made");
        gText.gameObject.SetActive(true);

        var wText = instantiated.GetChild(3).GetComponent<TextMeshProUGUI>();
        if (log.waterDrunk != 0) wText.SetText($"I drank {log.waterDrunk} glasses of water");
        else wText.SetText($"No entries made");
        wText.gameObject.SetActive(true);

        var mText = instantiated.GetChild(4).GetComponent<TextMeshProUGUI>();
        if (log.minutesMeditated != 0) mText.SetText($"I meditated for {log.minutesMeditated} minutes");
        else mText.SetText($"No entries made");
        mText.gameObject.SetActive(true);

        instantiated.gameObject.SetActive(true);
    }
}
