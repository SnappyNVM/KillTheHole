using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private Grid _grid;

    [Inject]
    private void Construct(Grid grid) => _grid = grid;

    private void Start() => _grid.Initalize();
}
