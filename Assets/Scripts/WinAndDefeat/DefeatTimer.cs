using UnityEngine;

public class DefeatTimer : MonoBehaviour
{
    private float _timeToDefeat;

    public float TimeToDefeat => _timeToDefeat;

    public void Initialize(float timeToDefeat) => _timeToDefeat = timeToDefeat;

    private void FixedUpdate() => _timeToDefeat -= Time.fixedDeltaTime;
}
