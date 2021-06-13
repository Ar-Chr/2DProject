using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkeletonAnimationEventCatcher : MonoBehaviour
{
    public UnityEvent SwingStartEvent;
    public UnityEvent CutStartEvent;
    public UnityEvent CutEndEvent;
    public UnityEvent AttackStartEvent;
    public UnityEvent AttackEndEvent;

    private void SwingStart() => SwingStartEvent.Invoke();

    private void CutStart() => CutStartEvent.Invoke();

    private void CutEnd() => CutEndEvent.Invoke();

    private void AttackStart() => AttackStartEvent.Invoke();

    private void AttackEnd() => AttackEndEvent.Invoke();
}
