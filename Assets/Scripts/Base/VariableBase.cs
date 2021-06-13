using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VariableBase<T> : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    [SerializeField] private T value;
    public T Value
    {
        get => value;
        set => this.value = value;
    }

    public static implicit operator T(VariableBase<T> var)
    {
        return var.Value;
    }
}
