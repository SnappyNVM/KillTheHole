using TMPro;
using UnityEngine;
using Zenject;

public class DefeatTimerText : GameModeUIElement<TimeOutDefeatCondition>
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _prefix;

    private DefeatTimer _defeatTimer;

    [Inject]
    private void Construct(DefeatTimer defeatTimer) => _defeatTimer = defeatTimer;

    private void FixedUpdate() => _text.text = _prefix + Mathf.Ceil(_defeatTimer.TimeToDefeat).ToString();
}
