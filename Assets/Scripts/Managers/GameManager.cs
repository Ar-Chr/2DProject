using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public KeyBinds KeyBinds;

    [SerializeField] private LevelManager levelManager;
    [Header("Events")]
    [SerializeField] private GameEvent playerDiedEvent;
    [SerializeField] private GameEvent playerReachedFinishEvent;
    [SerializeField] private GameEvent playerFinishedLastLevel;
    [Header("Options")]
    [SerializeField] private bool autoRestart;
    [SerializeField] private Text restartKeyHint;

    private bool canRestart;

    private void Start()
    {
        playerDiedEvent.AddListener(OnPlayerDied);
        playerReachedFinishEvent.AddListener(OnPlayerReachedFinish);
    }

    private void Update()
    {
        if (canRestart && Input.GetKeyDown(KeyBinds.Restart))
            RestartLevel(0);
    }

    private void OnPlayerDied()
    {
        if (autoRestart)
            RestartLevel(3);
        else
        {
            canRestart = true;
            if (restartKeyHint != null)
            {
                restartKeyHint.gameObject.SetActive(true);
                restartKeyHint.text = string.Format(restartKeyHint.text, KeyBinds.Restart.ToString());
            }
        }
    }

    private void OnPlayerReachedFinish()
    {
        this.DelayAction(() => levelManager.LoadNextLevel(), 3f);
    }

    private void RestartLevel(float delay = 3.0f) =>
        this.DelayAction(() => levelManager.RestartLevel(), delay);

    [ContextMenu("Set layer for all platforms")]
    private void SetLayerForAllPlatforms()
    {
        var platforms = FindObjectsOfType<PlatformEffector2D>();
        foreach (var platform in platforms)
        {
            platform.useColliderMask = false;
            platform.gameObject.layer = IntConstants.PlatformLayer;
        }
    }
}
