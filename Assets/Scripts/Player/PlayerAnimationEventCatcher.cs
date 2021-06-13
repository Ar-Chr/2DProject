using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimationEventCatcher : MonoBehaviour
{
    public UnityEvent shieldRaisedEvent;

    private void ShieldRaised() => shieldRaisedEvent.Invoke();
}
