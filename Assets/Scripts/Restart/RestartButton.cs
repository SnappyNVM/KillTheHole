using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        var sceneManager = new SceneManager();
        sceneManager.RestartCurrentScene();
    }
}
