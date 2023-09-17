using UnityEngine;
using Zenject;

public class PopUp : MonoBehaviour
{
    [SerializeField] private GameObject _popUp;

    private TimeChanger _timeChanger;

    [Inject]
    private void Construct(TimeChanger timeChanger) => _timeChanger = timeChanger;

    private void Start() => _popUp.SetActive(false);

    public void Open()
    {
        _popUp.SetActive(true);
        _timeChanger.StopTime();
    }
}
