using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private int _countOfCellsBySide;
    [SerializeField] private Transform _gridSquare;
    [SerializeField] private HoleSpawner _holeSpawner;
    [SerializeField] private MoleSpawner _moleSpawner;
    [SerializeField] private ObjectTransformer _objectTransfromer;
    [SerializeField] private ScoreHolder _scoreHolder;
    [SerializeField] private MoleParticlesSpawner _moleParticlesSpawner;
    [SerializeField] private MoleSpawnDelayDecreaser _delayDecreaser;
    [SerializeField] private WinPopUp _winPopUp;
    [SerializeField] private DefeatPopUp _defeatPopUp;
    [SerializeField] private TimeChanger _timeStoper;
    [SerializeField] private WinAndDefeatChecker _winAndDefeatChecker;
    [SerializeField] private DefeatTimer _defeatTimer;
    [SerializeField] private MoleParticlesSpawner _moleParticlesSpawner;
    [SerializeField] private MoleSpawnDelayDecreaser _delayDecreaser;

    private Grid _grid;

    public override void InstallBindings()
    {
        _grid = new Grid(_gridSquare, _countOfCellsBySide, _holeSpawner, _moleSpawner);
        Container.Bind<Grid>().FromInstance(_grid).AsSingle().Lazy();
        Container.Bind<MoleSpawner>().FromInstance(_moleSpawner).AsSingle().Lazy();
        Container.Bind<ObjectTransformer>().FromInstance(_objectTransfromer).AsSingle().Lazy();
        Container.Bind<ScoreHolder>().FromInstance(_scoreHolder).AsSingle();
        Container.Bind<MoleParticlesSpawner>().FromInstance(_moleParticlesSpawner).AsSingle().Lazy();
        Container.Bind<MoleSpawnDelayDecreaser>().FromInstance(_delayDecreaser).AsSingle().Lazy();
        Container.Bind<WinPopUp>().FromInstance(_winPopUp).AsSingle();
        Container.Bind<DefeatPopUp>().FromInstance(_defeatPopUp).AsSingle();
        Container.Bind<WinAndDefeatChecker>().FromInstance(_winAndDefeatChecker).AsSingle();
        Container.Bind<TimeChanger>().FromInstance(_timeStoper).AsSingle();
        Container.Bind<DefeatTimer>().FromInstance(_defeatTimer).AsSingle();
        Container.Bind<MoleParticlesSpawner>().FromInstance(_moleParticlesSpawner).AsSingle().Lazy();
        Container.Bind<MoleSpawnDelayDecreaser>().FromInstance(_delayDecreaser).AsSingle().Lazy();
    }
}
