using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected GameObject prompt;

    protected KeyBinds binds;
    private bool playerInVicinity;

    private void Start()
    {
        binds = FindObjectOfType<GameManager>().KeyBinds;
        SetPlayerInVicinity(false);
    }

    private void Update()
    {
        if (playerInVicinity && Input.GetKeyDown(binds.Interact))
            Interact();
    }

    protected abstract void Interact();

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            SetPlayerInVicinity(true);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            SetPlayerInVicinity(false);
    }

    private void SetPlayerInVicinity(bool inVicinity)
    {
        prompt.SetActive(inVicinity);
        playerInVicinity = inVicinity;
    }
}
