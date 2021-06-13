using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScreen : MonoBehaviour
{
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button toMainMenuButton;

    [SerializeField] private GameEvent playerReachedFinishEvent;
    [SerializeField] private GameEvent enemyKilledEvent;

    [SerializeField] private IntVariable coins;

    [SerializeField] private Text coinsText;
    [SerializeField] private Text enemiesText;

    private int maxCoins;
    private int enemies;
    private int maxEnemies;

    private LevelManager lm;

    private void Start()
    {
        gameObject.SetActive(false);
        playerReachedFinishEvent.AddListener(OnFinish);
        enemyKilledEvent.AddListener(() => enemies++);

        maxCoins = CountCoins();
        maxEnemies = FindObjectsOfType<Enemy>().Sum(e => 1);

        lm = FindObjectOfType<LevelManager>();
        nextLevelButton.onClick.AddListener(lm.LoadNextLevel);
        toMainMenuButton.onClick.AddListener(lm.LoadMainMenu);
    }

    private void OnFinish()
    {
        coinsText.text = $"{coins.Value}/{maxCoins}";
        enemiesText.text = $"{enemies}/{maxEnemies}";
        gameObject.SetActive(true);
    }

    private int CountCoins()
    {
        int existingCoins = FindObjectsOfType<Coin>().Sum(coin => 1);
        int spawnedCoins = FindObjectsOfType<SpawnObjects>()
            .Where(o => o.SpawnObject.GetComponent<Coin>() != null)
            .Select(o => o.Count).Sum();
        return existingCoins + spawnedCoins;
    }
}
