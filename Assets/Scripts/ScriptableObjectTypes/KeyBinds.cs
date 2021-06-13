using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewKeyBinds", menuName = "Scriptable Objects/Key Binds")]
public class KeyBinds : ScriptableObject
{
    public KeyCode Jump;
    public GameEvent JumpPressedEvent;
    public KeyCode GoLeft;
    public GameEvent GoLeftPressedEvent;
    public KeyCode GoRight;
    public GameEvent GoRightPressedEvent;
    public KeyCode Fall;
    public GameEvent FallPressedEvent;
    public KeyCode Shoot;
    public GameEvent ShootPressedEvent;
    public KeyCode Shield;
    public GameEvent ShieldPressedEvent;
    public KeyCode Interact;
    public GameEvent InteractPressedEvent;
    public KeyCode Restart;
    public GameEvent RestartPressedEvent;
}
