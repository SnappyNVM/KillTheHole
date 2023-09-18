using UnityEngine;
using Zenject;

public class MoleParticlesSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _hitParticles;
    [SerializeField] private ParticleSystem _hideParticles;
    [SerializeField] private ParticleSystem _dieParicles;

    private ObjectTransformer _transformer;

    private void Awake() => InitializeScale();

    [Inject]
    private void Construct(ObjectTransformer transformer) => _transformer = transformer; 

    private void InitializeScale()
    {
        for (int i = 0; i < _hitParticles.Length; i++)
        {
            _transformer.SetXZScaleByCell(_hitParticles[i].transform);
            _transformer.SetYScaleByCell(_hitParticles[i].transform);
        }
        _transformer.SetXZScaleByCell(_hideParticles.transform);
        _transformer.SetYScaleByCell(_hideParticles.transform);
        _transformer.SetXZScaleByCell(_dieParicles.transform);
        _transformer.SetYScaleByCell(_dieParicles.transform);
    }

    public void SpawnRandomHitParticle(Vector3 coordinates) => 
        SpawnParicles(coordinates, _hitParticles[Random.Range(0, _hitParticles.Length)]);

    public void SpawnHideParticles(Vector3 coordinates) =>
        SpawnParicles(coordinates, _hideParticles);

    public void SpawnDieParticles(Vector3 coordinates) =>
        SpawnParicles(coordinates, _dieParicles);

    private void SpawnParicles(Vector3 coordinates, ParticleSystem particleSystem) =>
        Instantiate(particleSystem, coordinates, Quaternion.identity);
}