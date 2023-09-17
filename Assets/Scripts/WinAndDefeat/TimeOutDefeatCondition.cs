public class TimeOutDefeatCondition : DefeatCondition
{
    private DefeatTimer _timer;

    public TimeOutDefeatCondition(DefeatTimer timer) => _timer = timer;

    public override bool CheackingDefeat() => _timer.TimeToDefeat <= 0;
}
