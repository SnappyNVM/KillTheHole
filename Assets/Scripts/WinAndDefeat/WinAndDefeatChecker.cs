using UnityEngine;
using Zenject;

public class WinAndDefeatChecker : MonoBehaviour
{
    [SerializeField] private int _scoresToWin;
    [SerializeField] private float _timeToDefeat;
    [SerializeField] private int _playerHealth;

    private ScoreHolder _scoreHolder;
    private DefeatPopUp _defeatPopUp;
    private WinPopUp _winPopUp;

    private DefeatCondition _defeatCondition;
    private WinCondition _winCondition;

    [Inject]
    private void Construct(ScoreHolder scoreHolder, DefeatPopUp defeatPopUp, WinPopUp winPopUp)
    {
        _scoreHolder = scoreHolder;
        _defeatPopUp = defeatPopUp;
        _winPopUp = winPopUp;
    }

    private void Update()
    {
        if (_winCondition.CheackingWin())
            _winPopUp.Open();
        if (_defeatCondition.CheackingDefeat())
            _defeatPopUp.Open();
    }

    private void Start() => _winCondition = new ScoreWinCondition(_scoreHolder, _scoresToWin);

    public void SetTimeOutDefeat() => _defeatCondition = new TimeOutDefeatCondition(_timeToDefeat);

    public void SetPlayerDeathDefeat() => _defeatCondition = new PlayerDeathDefeatCondition(_playerHealth);
}
