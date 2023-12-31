using System;
using UnityEngine;
using Zenject;

public class WinAndDefeatChecker : MonoBehaviour
{
    [SerializeField] private int _scoresToWin;
    [SerializeField, Min(0)] private float _timeToDefeat;
    [SerializeField, Min(1)] private int _hearth;

    private ScoreHolder _scoreHolder;
    private DefeatPopUp _defeatPopUp;
    private WinPopUp _winPopUp;
    private DefeatTimer _timer;
    private MoleSpawner _moleSpawner;
    private PlayerHealth _playerHealth;

    private DefeatCondition _defeatCondition;
    private WinCondition _winCondition;

    public Action<DefeatCondition> GameModeSelected;

    [Inject]
    private void Construct(ScoreHolder scoreHolder, DefeatPopUp defeatPopUp, WinPopUp winPopUp, DefeatTimer defeatTimer, MoleSpawner moleSpawner, PlayerHealth playerHealth)
    {
        _scoreHolder = scoreHolder;
        _defeatPopUp = defeatPopUp;
        _winPopUp = winPopUp;
        _timer = defeatTimer;
        _moleSpawner = moleSpawner;
        _playerHealth = playerHealth;
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

    public void SetTimeOutCondition()
    {
        _defeatCondition = new TimeOutDefeatCondition(_timer);
        GameModeSelected?.Invoke(_defeatCondition);
    }
    public void SetPlayerDeathCondition()
    {
        _defeatCondition = new PlayerDeathDefeatCondition(_hearth, _playerHealth, _moleSpawner);
        GameModeSelected?.Invoke(_defeatCondition);
    }
}
