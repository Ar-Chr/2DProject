using UnityEngine;
using System;

[CreateAssetMenu(fileName = "NewLevelSequence", menuName = "Scriptable Objects/Level Sequence")]
public class LevelSequence : ScriptableObject
{
    [SerializeField] private string[] levels;
    public string this[int index] => levels[index];

    public int Count => levels.Length;

    public int GetLevelNumber(string sceneName)
    {
        for (int i = 0; i < levels.Length; i++)
            if (levels[i] == sceneName)
                return i;
        throw new ArgumentException($"[LevelSequence] Sequence does not contain scene with name {sceneName}");
    }
}
