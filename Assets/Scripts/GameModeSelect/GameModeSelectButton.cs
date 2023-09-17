using UnityEngine;
using UnityEngine.UI;
using Zenject;

public abstract class GameModeSelectButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private WinAndDefeatChecker _checker;

    protected WinAndDefeatChecker Checker => _checker;
    public Button Button => _button;


    [Inject]
    private void Construct(WinAndDefeatChecker checker) => _checker = checker;

    private void Start() => _button.onClick.AddListener(SelectGameMode);

    protected abstract void SelectGameMode();
}