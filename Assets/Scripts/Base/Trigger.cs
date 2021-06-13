using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent triggerEvent;

    protected void Start()
    {
        var actions = GetComponents<TriggerAction>();
        foreach (var action in actions)
            triggerEvent.AddListener(action.Do);
    }
}
