using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private LevelManager lm;

    private void Awake()
    {
        lm = FindObjectOfType<LevelManager>();
        playButton.onClick.AddListener(lm.LoadFirstLevel);
        quitButton.onClick.AddListener(Application.Quit);
    }
}
