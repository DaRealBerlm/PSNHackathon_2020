using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataHandler : MonoBehaviour
{
    public static DataHandler instance { get; private set; }
    public DataFrame dataFrame { get; private set; }
    public AudioClip[] music { get; private set; }

    #region Init

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);

        dataFrame = SaveSystem.LoadData();
        if (dataFrame != null) SceneManager.LoadScene(1);

        music = Resources.LoadAll<AudioClip>("Music");
    }

    #endregion

    #region Public Functions

    public void SetName(string name)
    {
        dataFrame = new DataFrame(name);
        SceneManager.LoadScene(1);
        music = Resources.LoadAll<AudioClip>("Music");
    }

    public void UpdateMeditation(int time)
    {
        DateTime dateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        if (dataFrame.logs == null) dataFrame.logs = new Dictionary<DateTime, Log>();
        if (!dataFrame.logs.Keys.Contains(dateNow)) dataFrame.logs[dateNow] = new Log();

        dataFrame.logs[dateNow].minutesMeditated += time;
    }

    public int GetTodayWater()
    {
        DateTime dateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        if (dataFrame.logs == null) dataFrame.logs = new Dictionary<DateTime, Log>();
        if (!dataFrame.logs.Keys.Contains(dateNow)) dataFrame.logs[dateNow] = new Log();

        return dataFrame.logs[dateNow].waterDrunk;
    }

    public void DrinkWater()
    {
        DateTime dateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        if (dataFrame.logs == null) dataFrame.logs = new Dictionary<DateTime, Log>();
        if (!dataFrame.logs.Keys.Contains(dateNow)) dataFrame.logs[dateNow] = new Log();

        dataFrame.logs[dateNow].waterDrunk++;
    }

    public void AddGratitude(string toAdd)
    {
        toAdd = toAdd.ToLower();
        DateTime dateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        if (dataFrame.logs == null) dataFrame.logs = new Dictionary<DateTime, Log>();

        if (!dataFrame.logs.Keys.Contains(dateNow)) dataFrame.logs[dateNow] = new Log();
        
        if (!dataFrame.logs[dateNow].gratitude.Contains(toAdd)) dataFrame.logs[dateNow].gratitude.Add(toAdd);
    }

    #endregion

    #region Saving At Load
    private void OnApplicationPause(bool paused)
    {
        if (dataFrame == null) return;
        if (paused) SaveSystem.SaveData(dataFrame);
    }

    private void OnApplicationQuit()
    {
        if (dataFrame == null) return;
        SaveSystem.SaveData(dataFrame); 
    }
    #endregion
}