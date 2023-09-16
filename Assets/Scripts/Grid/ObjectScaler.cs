using Zenject;
using UnityEngine;

public class ObjectTransformer : MonoBehaviour
{
    [SerializeField, Tooltip("Коофицент размера по оси Y. Исходный размер при value=1.")]
    private float _heightModifer;
    [SerializeField, Tooltip("Коофицент высоты  положения по оси Y.")]
    private float _yPositionModifer;

    private Grid _grid;
    private float _scaleByXZ;
    private float _cellSideLength;

    [Inject]
    private void Construct(Grid grid)
    { 
        _grid = grid;
        CalculateData();
    }

    private void CalculateData()
    {
        _cellSideLength = _grid.GridSquare.transform.localScale.x / _grid.CountOfCellsBySide;
        _scaleByXZ = _cellSideLength - _cellSideLength * 0.1f;
    }

    public void RaiseAnObjectByCell(Transform transform) =>
        transform.Translate(Vector3.up * _yPositionModifer * _scaleByXZ * _heightModifer);

    public void SetXZScaleByCell(Transform transform) =>
        transform.localScale = new Vector3(_scaleByXZ, transform.localScale.y, _scaleByXZ);

    public void SetYScaleByCell(Transform transform) =>
         transform.localScale = new Vector3(transform.localScale.x, _heightModifer * _cellSideLength, transform.localScale.z);
}
