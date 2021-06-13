using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button toMainMenuButton;

    private LevelManager lm;
    [RuntimeInitializeOnLoadMethod]
    private void Start()
    {
        lm = FindObjectOfType<LevelManager>();
        resumeButton.onClick.AddListener(() => gameObject.SetActive(false));
        toMainMenuButton.onClick.AddListener(lm.LoadMainMenu);
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
