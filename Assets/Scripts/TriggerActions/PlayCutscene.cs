using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class PlayCutscene : TriggerAction
{
    [SerializeField] private GameEvent cutsceneStartedEvent;
    [SerializeField] private GameEvent cutsceneEndedEvent;
    [Space]
    [SerializeField] private GameObject blendListObj;
    [SerializeField] private Transform cmvcam;
    [Space]
    [SerializeField] private string[] lines;
    [Space] 
    [SerializeField] private bool useLetterboxing;
    [SerializeField] private GameObject blackBars;

    private new Camera camera;

    private Text text;
    private float timeBetweenSymbols = 0.06f;
    private float timeBetweenLines = 2.2f;

    private float currentTimeBetweenSymbols;
    private float currentTimeBetweenLines;

    private int currentSymbol;
    private int currentLine;

    private bool cutsceneStarted;
    private bool outputtingText;

    private Vector3 initialPosition;

    private void Start()
    {
        text = GetComponentInChildren<Text>();
        text.text = string.Empty;
        camera = FindObjectOfType<Camera>();
    }

    public override void Do()
    {
        if (useLetterboxing)
            blackBars.SetActive(true);
        cutsceneStartedEvent.Invoke();
        initialPosition = camera.transform.position;
        cutsceneStarted = true;
        blendListObj.SetActive(true);
    }

    private void Update()
    {
        if (!cutsceneStarted)
            return;

        if (!outputtingText && camera.transform.position == cmvcam.position)
            outputtingText = true;

        if (!outputtingText)
            return;

        if (currentLine == lines.Length)
        {
            blendListObj.SetActive(false);
            if ((camera.transform.position - initialPosition).sqrMagnitude < 0.005f)
            {
                if (useLetterboxing)
                    blackBars.SetActive(false);
                cutsceneEndedEvent.Invoke();
                Destroy(gameObject);
            }
        }
        else if (currentSymbol == lines[currentLine].Length)
        {
            currentTimeBetweenLines += Time.deltaTime;
            if (currentTimeBetweenLines >= timeBetweenLines)
            {
                text.text = string.Empty;
                currentTimeBetweenLines = 0;
                currentLine++;
                currentSymbol = 0;
            }
        }
        else
        {
            currentTimeBetweenSymbols += Time.deltaTime;
            if (currentTimeBetweenSymbols >= timeBetweenSymbols)
            {
                currentTimeBetweenSymbols -= timeBetweenSymbols;
                text.text += lines[currentLine][currentSymbol];
                currentSymbol++;
            }
        }
    }
}
