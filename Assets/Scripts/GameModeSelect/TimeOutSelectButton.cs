public class TimeOutSelectButton : GameModeSelectButton
{
    protected override void SelectGameMode() => Checker.SetTimeOutCondition();
}
