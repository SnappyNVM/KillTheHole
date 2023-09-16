using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private int _countOfCellsBySide;
    [SerializeField] private Transform _gridSquare;
    [SerializeField] private HoleSpawner _holeSpawner;
    [SerializeField] private MoleSpawner _moleSpawner;

    private Grid _grid;

    public override void InstallBindings()
    {
        _grid = new Grid(_gridSquare, _countOfCellsBySide, _holeSpawner, _moleSpawner);
        Container.Bind<Grid>().FromInstance(_grid).AsSingle().Lazy();
    }
}
