public class PlayerDeathDefeatCondition : DefeatCondition
{
    private PlayerHealth _playerHealth;

    public PlayerDeathDefeatCondition(int health) => _playerHealth = new PlayerHealth(health);

    public override bool CheackingDefeat() => _playerHealth.Health <= 0;
}
