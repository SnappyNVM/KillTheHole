using System;

public class PlayerHealth
{
    private int _currentHealth;

    public int Health => _currentHealth;

    public PlayerHealth(int currentHealth)
    {
        if (currentHealth < 0) throw new ArgumentException("Invalid health value", nameof(currentHealth));

        _currentHealth = currentHealth;
    }

    public void TakeDamage() => _currentHealth--;
}
