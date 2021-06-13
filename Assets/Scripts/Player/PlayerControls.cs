using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
#pragma warning disable 0649
    [Header("Events")]
    [SerializeField] private GameEvent playerDiedEvent;
    [SerializeField] private BoolGameEvent shieldRaisedEvent;
    [SerializeField] private GameEvent playerReachedFinishEvent;
    [SerializeField] private GameEvent cutsceneStartedEvent;
    [SerializeField] private GameEvent cutsceneEndedEvent;

    private KeyBinds binds;

    void Start()
    {
        binds = FindObjectOfType<GameManager>().KeyBinds;
        playerDiedEvent.AddListener(() => enabled = false);
        playerReachedFinishEvent.AddListener(() => enabled = false);
        cutsceneStartedEvent.AddListener(() => enabled = false);
        cutsceneEndedEvent.AddListener(() => enabled = true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(binds.Shoot))
        {
            binds.ShootPressedEvent.Invoke();
        }

        if (Input.GetKeyDown(binds.Shield))
        {
            shieldRaisedEvent.Invoke(true);
        }
        if (Input.GetKeyUp(binds.Shield))
        {
            shieldRaisedEvent.Invoke(false);
        }

        if (Input.GetKey(binds.GoLeft))
        {
            binds.GoLeftPressedEvent.Invoke();
        }
        if (Input.GetKey(binds.GoRight))
        {
            binds.GoRightPressedEvent.Invoke();
        }

        if (Input.GetKeyDown(binds.Jump))
        {
            binds.JumpPressedEvent.Invoke();
        }

        if (Input.GetKeyDown(binds.Fall))
        {
            Physics2D.IgnoreLayerCollision(IntConstants.PlayerLayer, IntConstants.PlatformLayer, true);
            this.DelayAction(() => Physics2D.IgnoreLayerCollision(IntConstants.PlayerLayer, IntConstants.PlatformLayer, false), 0.4f);
        }
    }
#pragma warning restore 0649
}