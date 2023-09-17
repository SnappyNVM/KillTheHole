using UnityEngine;

public class MoleSpawnDelayDecreaser : MonoBehaviour
{
    [field: SerializeField, Min(0)] public float MinSpawnDelay { get; private set; }
    [field: SerializeField, Min(0)] public float StartSpawnDelay { get; private set; }
    [field: SerializeField, Min(0)] public float DelayDecrease { get; private set; }
    [field: SerializeField, Min(0)] public float DelayDecreaseDelay { get; private set; }
    public float CurrentDelay { get; private set; }

    private void Awake()
    {
        CurrentDelay = StartSpawnDelay;
        InvokeRepeating(nameof(DecreaseSpawnDelay), 0, DelayDecreaseDelay);
    }

    private void DecreaseSpawnDelay()
    {
        if (CurrentDelay - DelayDecrease <= MinSpawnDelay)
            CurrentDelay = MinSpawnDelay;
        else 
            CurrentDelay -= DelayDecrease;
    }
        
}
