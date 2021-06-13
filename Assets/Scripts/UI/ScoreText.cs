using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private IntVariable score;

    private string initialText;

    private void Start()
    {
        initialText = scoreText.text;   
    }

    private void Update()
    {
        scoreText.text = string.Format(initialText, score.Value.ToString());
    }
}
