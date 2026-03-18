using UnityEngine;

public class PortalTrigger : MoveTrigger
{
    [SerializeField] private CanvasGroup welcomePanel;
    [SerializeField] private CanvasGroup moneyPanel;

    protected override void OnTriggerEnter(Collider other)
    {
        welcomePanel.gameObject.SetActive(true);
        moneyPanel.gameObject.SetActive(true);
        base.OnTriggerEnter(other);
    }

    private void Update()
    {
        if(!welcomePanel.gameObject.activeSelf) return;
        if (welcomePanel.gameObject.activeSelf && Input.anyKeyDown)
            welcomePanel.gameObject.SetActive(false);
    }
}
