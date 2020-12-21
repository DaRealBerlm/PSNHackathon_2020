using System;
using UnityEngine;
using UnityEngine.UI;

public class HydrationManager : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
    [SerializeField] private float delta = 2f;
    private int waterDrunk = 0;

    private void Awake()
    {
        waterDrunk = DataHandler.instance.GetTodayWater();
    }

    private void Update()
    { 
        slider.value = Mathf.Lerp(slider.value, waterDrunk, Time.deltaTime * delta);
    }

    public void DrinkWater()
    {
        DataHandler.instance.DrinkWater();
        waterDrunk = DataHandler.instance.GetTodayWater();
    }

    public void GoBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
