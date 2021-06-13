using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelSequence levels;
    [SerializeField] private IntGameEvent playerFinishedLastLevel;

    private Scene currentScene =>
        SceneManager.GetActiveScene();
    private int currentLevelNumber => 
        levels.GetLevelNumber(SceneManager.GetActiveScene().name);

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(levels[0]);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadSceneAsync(levels[1]);
    }

    public void LoadNextLevel()
    {
        if (currentLevelNumber == levels.Count - 1)
            playerFinishedLastLevel?.Invoke();
        else
            SceneManager.LoadSceneAsync(levels[currentLevelNumber + 1]);
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(currentScene.buildIndex);
    }
}
