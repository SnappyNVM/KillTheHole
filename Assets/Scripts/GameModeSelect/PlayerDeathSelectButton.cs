public class PlayerDeathSelectButton : GameModeSelectButton
{
    protected override void SelectGameMode() => Checker.SetPlayerDeathDefeat();
}
