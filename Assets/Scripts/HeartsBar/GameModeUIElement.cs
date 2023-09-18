using UnityEngine;
using Zenject;

public class GameModeUIElement<T> : MonoBehaviour where T : DefeatCondition
{
    [Inject]
    private void Construct(WinAndDefeatChecker cheacker) => print("���");

    private void Close(DefeatCondition condition) {
        if (condition.GetType() != typeof(T)) 
            Destroy(gameObject);
    }
}
