using System.Collections.Generic;
using UnityEngine;

public class HeartsBar : MonoBehaviour
{
    [SerializeField] private Heart _heartPrefab;
    [SerializeField] private Vector3 _heartsOffset;

    private List<Heart> _spawnedHearts;
    private PlayerHealth _playerHealth;

    private void Awake() => _spawnedHearts = new List<Heart>();

    private void SetHearts()
    {
        DestroyHearts();
        SpawnHearts();
    }
    private void SpawnHearts()
    {
        for (int i = 0; i < _playerHealth.Health; i++)
            _spawnedHearts.Add(Instantiate(_heartPrefab, transform.position + _heartsOffset * i, Quaternion.identity));
    }
    private void DestroyHearts()
    {
        if (_spawnedHearts.Count == 0 || _spawnedHearts == null) return;
        foreach (var heart in _spawnedHearts)
        {
            _spawnedHearts.Remove(heart);
            Destroy(heart.gameObject);
        }
    }
}
