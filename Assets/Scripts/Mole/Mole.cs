using UnityEngine;

public class Mole : MonoBehaviour
{
    [Header("Mole config")]
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _scoreMultiplier;
    [SerializeField, Tooltip("In seconds.")]
    private float _lifeTime;
    
    private int _givenScores;
    private MoleSpawner _moleSpawner;
    private MoleHealth _health;
    private ScoreHolder _scoreHolder;
    private MoleParticlesSpawner _particlesSpawner;

    public void Initialize(ScoreHolder scoreHolder, MoleSpawner moleSpawner, MoleParticlesSpawner moleParticlesSpawner)
    {
        _health = new MoleHealth(_maxHealth, _givenScores);
        _scoreHolder = scoreHolder;
        _moleSpawner = moleSpawner;
        _particlesSpawner = moleParticlesSpawner;
        _givenScores = _maxHealth * _scoreMultiplier;
        _health.Death += SpawnDieParticles;
        _health.Death += HideAMole;
        _health.Death += IncreaseScore;
        Invoke(nameof(RunAwayMole), _lifeTime);
    }

    public void TakeDamage()
    {
        _particlesSpawner.SpawnRandomHitParticle(transform.position);
        _health.TakeDamage();
    }

    private void IncreaseScore() => _scoreHolder.IncreaseScores(_givenScores);

    private void SpawnDieParticles() => _particlesSpawner.SpawnDieParticles(transform.position);

    private void HideAMole()
    {
        _moleSpawner.ReleaseCell(transform.position);
        Destroy(gameObject);
    }

    private void RunAwayMole()
    {
       _particlesSpawner.SpawnHideParticles(transform.position);
        HideAMole();
        _moleSpawner.OnMoleRunAway();
    }
}
