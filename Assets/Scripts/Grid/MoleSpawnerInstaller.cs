using UnityEngine;
using Zenject;

public class MoleSpawnerInstaller : MonoInstaller
{
    [SerializeField] private HoleSpawner _spawner;
    public override void InstallBindings()
    {
        Container.Bind<HoleSpawner>().FromInstance(_spawner).AsSingle();
    }
}
