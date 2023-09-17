using System;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    private int _currentScores;

    public event Action<int> ScoreIncreased;

    public void IncreaseScores(int scores)
    {
        if (scores < 0) throw new ArgumentException();

        _currentScores += scores;
        ScoreIncreased?.Invoke(_currentScores);
    }
}
