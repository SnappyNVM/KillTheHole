using System;

public class MoleHealth
{
    private int _maxHealth;
    private int _scoreToGive;
    private int _currentHealth;

    public int ScoreToGive => _scoreToGive;
    public event Action Death;

    public MoleHealth(int maxHealth)
    {
        _maxHealth = maxHealth;
        _scoreToGive = maxHealth * 10;
        _currentHealth = _maxHealth;
    }

    public void TakeDamage()
    {
        _currentHealth--;
        if (_currentHealth <= 0)
            Death?.Invoke();
    }
}
