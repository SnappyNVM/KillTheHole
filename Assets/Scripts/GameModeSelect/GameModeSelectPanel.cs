using System;
using UnityEngine;
using Zenject;

public class GameModeSelectPanel : MonoBehaviour
{
    [SerializeField] private GameModeSelectButton[] _buttons;

    private TimeChanger _timeChanger;

    [Inject]
    private void Construct(TimeChanger timeChanger) => _timeChanger = timeChanger;

    private void Start() => Array.ForEach(_buttons, (button) => button.Button.onClick.AddListener(ClosePanel));

    private void ClosePanel()
    {
        _timeChanger.StartTime();
        Destroy(gameObject);
    }
}
