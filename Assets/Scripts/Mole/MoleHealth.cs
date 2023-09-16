using System;

public abstract class MoleHealth
{
    private int _maxHealth;
    private int _givenScores;
    private int _currentHealth;

    public int GivenScores => _givenScores;
    public event Action Death;

    public void TakeDamage()
    {
        _currentHealth--;
        if (_currentHealth <= 0)
            Death?.Invoke();
    }
}
