using System;
using System.Collections;
using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _scoreMultiplier;
    [SerializeField, Tooltip("In seconds.")]
    private float _lifeTime;
    
    private int _givenScores;
    private MoleSpawner _moleSpawner;
    private MoleHealth _health;
    private ScoreHolder _scoreHolder;
   
    public void Initialize(ScoreHolder scoreHolder, MoleSpawner moleSpawner)
    {
        _health = new MoleHealth(_maxHealth, _givenScores);
        _scoreHolder = scoreHolder;
        _moleSpawner = moleSpawner;
        _givenScores = _maxHealth * _scoreMultiplier;
        _health.Death += HideAMole;
        _health.Death += IncreaseScore;
        Invoke(nameof(HideAMole), _lifeTime);
    }

    public void TakeDamage() => _health.TakeDamage();

    private void IncreaseScore() => _scoreHolder.IncreaseScores(_givenScores);

    private void HideAMole()
    {
        Destroy(gameObject);
        _moleSpawner.ReleaseCell(transform.position);
    }
}
