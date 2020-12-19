using UnityEngine;

[CreateAssetMenu(fileName = "Activity", menuName = "Brain Buddy/Create new activity", order = 0)]
public class Activity : ScriptableObject
{
    public new string name = "";
    public string description = "";
    public int sceneIndex = 0;
    public string btnText;
    [Space]
    public Color color = default;
}
