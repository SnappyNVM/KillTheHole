using UnityEngine;

public class TimeChanger : MonoBehaviour
{
    private void Start() => StopTime();
    public void StopTime() => Time.timeScale = 0;
    public void StartTime() => Time.timeScale = 1;
}
