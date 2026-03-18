using UnityEngine;
using TMPro;

public class MessengerButton : ButtonAction
{
    [SerializeField] private CanvasGroup _messenger;
    [SerializeField] private TextMeshProUGUI _messageText;
    [SerializeField] private string _message;
    
    protected override void Awake()
    {
        base.Awake();
        _messageText.text = _message;
    }
    
    protected override void Press()
    {
        ShowMessage();
        base.Press();
    }

    protected override void Release()
    {
        ShowMessage();
        base.Release();
    }

    private void ShowMessage()
    {
        _messenger.gameObject.SetActive(!_messenger.gameObject.activeSelf);
    }
}
