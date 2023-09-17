using UnityEngine;
using Zenject;
public class ScoreHolderInstaller : MonoInstaller
{
    [SerializeField] private ScoreHolder _scoreHolder;

    public override void InstallBindings()
    {
        Container.Bind<ScoreHolder>().FromInstance(_scoreHolder).AsSingle();
    }
}
