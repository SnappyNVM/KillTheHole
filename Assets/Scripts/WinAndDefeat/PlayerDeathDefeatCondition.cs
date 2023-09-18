public class PlayerDeathDefeatCondition : DefeatCondition
{
    private PlayerHealth _playerHealth;

    public PlayerDeathDefeatCondition(int health, PlayerHealth playerHealth ,MoleSpawner moleSpawner)
    {
        _playerHealth = playerHealth;
        _playerHealth.Initialize(health);
        moleSpawner.MoleRunAway += _playerHealth.TakeDamage;
    }

    public override bool CheackingDefeat() => _playerHealth.Health <= 0;
}
