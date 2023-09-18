using UnityEngine;
using Zenject;

public class GameModeUIElement<T> : MonoBehaviour where T : DefeatCondition
{
    private WinAndDefeatChecker _checker;

    [Inject]
    private void Construct(WinAndDefeatChecker checker) => _checker = checker;

    private void Start() => _checker.GameModeSelected += Close;

    private void Close(DefeatCondition condition) {
        if (condition.GetType() != typeof(T)) 
            Destroy(gameObject);
    }
}
