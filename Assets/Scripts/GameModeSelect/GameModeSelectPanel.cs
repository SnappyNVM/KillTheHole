using System;
using UnityEngine;
using Zenject;

public class GameModeSelectPanel : MonoBehaviour
{
    [SerializeField] private GameModeSelectButton[] _buttons;

    private TimeStoper _timeStoper;

    [Inject]
    private void Construct(TimeStoper timeStoper) => _timeStoper = timeStoper;

    private void Start() => Array.ForEach(_buttons, (button) => button.Button.onClick.AddListener(ClosePanel));

    private void ClosePanel()
    {
        _timeStoper.StartTime();
        Destroy(gameObject);
    }
}
