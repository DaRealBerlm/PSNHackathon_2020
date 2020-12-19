using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    [SerializeField] private Transform activityTemplate = null;
    [SerializeField] private Activity[] activies = null;

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
                SceneManager.LoadScene(activity.sceneIndex);
            });

            btn.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(activity.btnText);
            spawned.GetChild(3).GetComponent<Image>().color = activity.color;
        }
    }
}
