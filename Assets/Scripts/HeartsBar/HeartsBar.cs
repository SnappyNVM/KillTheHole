using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HeartsBar : MonoBehaviour
{
    [SerializeField] private Heart _heartPrefab;
    [SerializeField] private Vector3 _heartsOffset;

    private List<Heart> _spawnedHearts = new List<Heart>();
    private PlayerHealth _playerHealth;

    [Inject]
    private void Construct(PlayerHealth playerHealth) => _playerHealth = playerHealth;

    private void Start() => _playerHealth.HealthChanged += SetHearts;

    private void SetHearts()
    {
        DestroyHearts();
        SpawnHearts();
    }
    private void SpawnHearts()
    {
        if (_playerHealth.Health == 0) return;
        for (int i = 0; i < _playerHealth.Health; i++)
            _spawnedHearts.Add(Instantiate(_heartPrefab, transform.position + _heartsOffset * i, Quaternion.identity, transform));
    }
    private void DestroyHearts()
    {
        if (_spawnedHearts.Count == 0 || _spawnedHearts == null) return;
        for (int i = _spawnedHearts.Count - 1; i >= 0; i--)
            Destroy(_spawnedHearts[i].gameObject);
        _spawnedHearts.Clear();
    }
}
