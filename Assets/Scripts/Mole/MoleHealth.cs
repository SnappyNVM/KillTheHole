using UnityEngine;

public class MoleHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _givenScores;

    public int GivenScores => _givenScores;

    private int _currentHealth;

    public void TakeDamage()
    {
        _currentHealth--;
        if (_currentHealth <= 0)
            Death();
    }
    private void Death()
    {
        Destroy(gameObject);
    }
}
