using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _givenScores;

    private MoleHealth _health;

    private void Start()
    {
        _health = new MoleHealth(_maxHealth, _givenScores);
        _health.Death += Death;
    }

    public void TakeDamage() => _health.TakeDamage();

    private void Death() => Destroy(gameObject);
}
