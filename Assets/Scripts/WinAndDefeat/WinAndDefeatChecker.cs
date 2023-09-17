using UnityEngine;
using Zenject;

public class WinAndDefeatChecker : MonoBehaviour
{
    [SerializeField] private int _scoresToWin;
    [SerializeField, Min(0)] private float _timeToDefeat;
    [SerializeField] private int _playerHealth;

    private ScoreHolder _scoreHolder;
    private DefeatPopUp _defeatPopUp;
    private WinPopUp _winPopUp;
    private DefeatTimer _timer;

    private DefeatCondition _defeatCondition;
    private WinCondition _winCondition;

    [Inject]
    private void Construct(ScoreHolder scoreHolder, DefeatPopUp defeatPopUp, WinPopUp winPopUp, DefeatTimer defeatTimer)
    {
        _scoreHolder = scoreHolder;
        _defeatPopUp = defeatPopUp;
        _winPopUp = winPopUp;
        _timer = defeatTimer;
    }

    private void Start()
    {
        _winCondition = new ScoreWinCondition(_scoreHolder, _scoresToWin);
        _defeatCondition = new NothingDefeatCondition();
        _timer.Initialize(_timeToDefeat);
    }

    private void Update()
    {
        if (_winCondition.CheackingWin())
            _winPopUp.Open();
        if (_defeatCondition.CheackingDefeat())
            _defeatPopUp.Open();
    }

    public void SetTimeOutCondition() => _defeatCondition = new TimeOutDefeatCondition(_timer);
    public void SetPlayerDeathCondition() => _defeatCondition = new PlayerDeathDefeatCondition(_playerHealth);
}
