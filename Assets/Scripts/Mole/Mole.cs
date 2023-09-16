using UnityEngine;
using Zenject;

public class Mole : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    
    private int _givenScores;
    private MoleHealth _health;
    private ScoreHolder _scoreHolder;

    public void Init(ScoreHolder scoreHolder) => _scoreHolder = scoreHolder;
    
    private void Start()
    {
        _health = new MoleHealth(_maxHealth, _givenScores);
        _givenScores = _maxHealth * 10;
        _health.Death += Death;
    }

    public void TakeDamage() => _health.TakeDamage();

    private void Death() {
        _scoreHolder.IncreaseScores(_givenScores);
        Destroy(gameObject);
    } 
}
