using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _currentHealth;

    public int Health => _currentHealth;

    public void Initialize(int currentHealth)
    {
        if (currentHealth < 0) throw new ArgumentException("Invalid health value", nameof(currentHealth));

        _currentHealth = currentHealth;
    }

    public void TakeDamage() => _currentHealth--;
}
