using System;
using System.Collections.Generic;

[Serializable]
public class DataFrame
{
    public string name;
    public Dictionary<DateTime, Log> logs;
    public List<Task> tasks;
    public List<Quest> quests;

    public DataFrame(string name)
    {
        this.name = name;
        logs = new Dictionary<DateTime, Log>();
        tasks = new List<Task>();
        quests = new List<Quest>();
    }
}

[Serializable]
public class Log
{
    public List<string> gratitude;
    public int waterDrunk;
    public int minutesMeditated;

    public Log()
    {
        gratitude = new List<string>();
    }
}

[Serializable]
public class Task
{
    public string label;
    public DateTime toRemindAt;
    public bool isCompleted;

    public Task(string label, DateTime toRemindAt, bool isCompleted)
    {
        this.label = label;
        this.toRemindAt = toRemindAt;
        this.isCompleted = isCompleted;
    }

    public Task(string label, DateTime toRemindAt)
    {
        this.label = label;
        this.toRemindAt = toRemindAt;
        isCompleted = false;
    }
}

[Serializable]
public class Quest
{
    public string label;
    public bool isCompleted;

    public Quest(string label)
    {
        this.label = label;
        isCompleted = false;
    }

    public Quest(string label, bool isCompleted)
    {
        this.label = label;
        this.isCompleted = isCompleted;
    }
}