using UnityEngine;
using Zenject;

public class PopUp : MonoBehaviour
{
    [SerializeField] private GameObject _popUp;

    private TimeStoper _timeStoper;

    [Inject]
    private void Construct(TimeStoper timeStoper) => _timeStoper = timeStoper;

    private void Start() => _popUp.SetActive(false);

    public void Open()
    {
        _popUp.SetActive(true);
        _timeStoper.StopTime();
    }
}
