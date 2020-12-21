using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HomeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI headerText = null;
    [Space]
    [SerializeField] private Transform activityTemplate = null;
    [SerializeField] private Activity[] activies = null;
    [Space]
    [SerializeField] private GameObject loadingOverlay = null;

    private void Awake()
    {
        Array.Sort(activies, new Comparison<Activity>(
            (a1, a2) => a1.sceneIndex.CompareTo(a2.sceneIndex)));

        foreach (Activity activity in activies)
        {
            Transform spawned = Instantiate(activityTemplate, transform);
            spawned.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(activity.name);
            spawned.GetChild(1).GetComponent<TextMeshProUGUI>().SetText(activity.description);

            Transform btn = spawned.GetChild(2);
            btn.GetComponent<Image>().color = activity.color;

            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                StartCoroutine(LoadSceneAsync(activity.sceneIndex));
            });

            btn.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(activity.btnText);
            spawned.GetChild(3).GetComponent<Image>().color = activity.color;
        }

        string currentTime = "";

        if (DateTime.Now.Hour <= 11 && DateTime.Now.Minute <= 59) currentTime = "Morning";
        else if (DateTime.Now.Hour <= 15 && DateTime.Now.Minute <= 59) currentTime = "Afternoon";
        else if (DateTime.Now.Hour <= 19 && DateTime.Now.Minute <= 30) currentTime = "Evening";
        else currentTime = "Night";

        headerText?.SetText(headerText.text.Replace("name", DataHandler.instance.dataFrame.name).Replace("time", currentTime));
    }

    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        loadingOverlay.SetActive(true);
        AsyncOperation loadingScene = SceneManager.LoadSceneAsync(sceneIndex);

        Transform toSpin = loadingOverlay.transform.GetChild(0);
        while (!loadingScene.isDone)
        {
            Vector3 currentRot = toSpin.rotation.eulerAngles;
            currentRot.z += 100 * Time.deltaTime;
            toSpin.eulerAngles = currentRot;
            yield return null;
        }
    }

    public void Logs()
    {
        SceneManager.LoadScene("Logs");
    }
}
