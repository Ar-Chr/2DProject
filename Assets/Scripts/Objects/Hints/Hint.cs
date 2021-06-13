using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    [SerializeField] protected GameObject message;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(StringConstants.PlayerTag))
            message.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(StringConstants.PlayerTag))
            message.gameObject.SetActive(false);
    }
}
