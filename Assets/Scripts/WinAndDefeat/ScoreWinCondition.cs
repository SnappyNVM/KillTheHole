public class ScoreWinCondition : WinCondition
{
    private int _neededScores;
    private ScoreHolder _scoreHolder;

    public ScoreWinCondition(ScoreHolder scoreHolder, int neededScores)
    {
        _neededScores = neededScores;
        _scoreHolder = scoreHolder;
    }

    public override bool CheackingWin() => _scoreHolder.Scores >= _neededScores;
}
