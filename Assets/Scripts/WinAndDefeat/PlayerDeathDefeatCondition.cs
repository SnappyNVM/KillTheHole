public class PlayerDeathDefeatCondition : DefeatCondition
{
    private PlayerHealth _playerHealth;

    public PlayerDeathDefeatCondition(int health, MoleSpawner moleSpawner)
    {
        _playerHealth = new PlayerHealth(health);
        moleSpawner.CellReleased += _playerHealth.TakeDamage;
    }

    public override bool CheackingDefeat() => _playerHealth.Health <= 0;
}
