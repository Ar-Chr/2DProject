using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Health health;
    [Space]
    [SerializeField] private GameObject youDiedText;
    [SerializeField] private GameEvent playerDiedEvent;

    private void Start()
    {
        playerDiedEvent.AddListener(() => youDiedText.SetActive(true));
    }

    private void Update()
    {
        slider.value = health.healthPercentage;
    }
}
