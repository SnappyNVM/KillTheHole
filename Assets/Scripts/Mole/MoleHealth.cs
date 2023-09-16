using System;

public class MoleHealth
{
    private int _maxHealth;
    private int _givenScores;
    private int _currentHealth;

    public int GivenScores => _givenScores;
    public event Action Death;

    public MoleHealth(int maxHealth, int givenScores)
    {
        _maxHealth = maxHealth;
        _givenScores = givenScores;
        _currentHealth = _maxHealth;
    }
    
    public void TakeDamage()
    {
        _currentHealth--;
        if (_currentHealth <= 0)
            Death?.Invoke();
    }
}
