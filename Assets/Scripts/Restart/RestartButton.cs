using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Start() =>
        _button.onClick.AddListener(() => new SceneManager().RestartCurrentScene());
}
