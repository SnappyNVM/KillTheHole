using System;
using UnityEngine;
using Zenject;

public class TimeOutDefeatCondition : DefeatCondition, IFixedTickable
{
    private float _timeToDefeat;
    private float _currentTime;

    public TimeOutDefeatCondition(float timeToDefeat)
    {
        if (timeToDefeat < 0) throw new ArgumentException("Invalid time value", nameof(timeToDefeat));
        _timeToDefeat = timeToDefeat;
        _currentTime = _timeToDefeat;
    }

    public void FixedTick()
    {
        _currentTime -= Time.fixedDeltaTime;
    }

    public override bool CheackingDefeat() => _currentTime <= 0;
}
