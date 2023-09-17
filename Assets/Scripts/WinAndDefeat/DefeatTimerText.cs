using TMPro;
using UnityEngine;
using Zenject;

public class DefeatTimerText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private DefeatTimer _defeatTimer;

    [Inject]
    private void Construct(DefeatTimer defeatTimer) => _defeatTimer = defeatTimer;

    private void FixedUpdate() => _text.text = Mathf.Ceil(_defeatTimer.TimeToDefeat).ToString();
}
