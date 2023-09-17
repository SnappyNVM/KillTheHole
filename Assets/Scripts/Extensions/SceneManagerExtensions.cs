using UnityEngine.SceneManagement;

public static class SceneManagerExtensions
{
    public static void RestartCurrentScene(this SceneManager sceneManager) => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
