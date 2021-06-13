using UnityEngine;
using UnityEngine.UI;

public abstract class FormatHint : MonoBehaviour
{
    [SerializeField] protected GameObject message;

    protected object[] inserts;
    protected Text textObj;
    protected string initialText;

    private void Start()
    {
        textObj = message.GetComponentInChildren<Text>();
        initialText = textObj.text;
    }

    private void UpdateMessage()
    {
        UpdateInserts();
        textObj.text = string.Format(initialText, inserts);
    }

    protected abstract void UpdateInserts();

    private void OnTriggerEnter2D(Collider2D other)
    {
        UpdateMessage();
        if (other.CompareTag(StringConstants.PlayerTag))
            message.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(StringConstants.PlayerTag))
            message.gameObject.SetActive(false);
    }
}
