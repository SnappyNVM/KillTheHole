using UnityEngine;
using Zenject;

public class PopUp : MonoBehaviour
{
    [SerializeField] private GameObject _popUp;

    private TimeChanger _timeStoper;

    [Inject]
    private void Construct(TimeChanger timeStoper) => _timeStoper = timeStoper;

    private void Start() => _popUp.SetActive(false);

    public void Open()
    {
        _popUp.SetActive(true);
        _timeStoper.StopTime();
    }
}
