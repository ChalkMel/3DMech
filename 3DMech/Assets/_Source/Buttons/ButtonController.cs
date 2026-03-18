using TMPro;
using UnityEngine;

internal enum ButtonType
{
  MESSENGER,
  PUZZLE,
  KILLER
}
public class ButtonController : MonoBehaviour
{
    [SerializeField] private ButtonType buttonType;
    [SerializeField] private Color pressedColor;
    [SerializeField] private Color unpressedColor;
    
    [Header("Puzzle Settings")] 
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject wall;
    
    [Header("Messenger Settings")] 
    [SerializeField] private CanvasGroup messenger;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private string message;
    
    [Header("Killer Settings")] 
    [SerializeField] private GameObject floor;
    
    private MeshRenderer _meshRenderer;
    private MeshRenderer _boxMeshRenderer;
    private bool _isBoxOn;
    private void Awake()
    {
      _meshRenderer = GetComponent<MeshRenderer>();
      _meshRenderer.material.color = unpressedColor;
      if (buttonType == ButtonType.MESSENGER)
        messageText.text = message;
      if (buttonType != ButtonType.PUZZLE) return;
      _boxMeshRenderer = box.GetComponent<MeshRenderer>();
      _boxMeshRenderer.material.color = unpressedColor;
    }

    private void OnTriggerEnter(Collider other) => Turn(other, pressedColor);
    
    private void OnTriggerExit(Collider other) => Turn(other,  unpressedColor);

    private void Turn(Collider other, Color color)
    {
      if (other.CompareTag("Player"))
      {
        switch (buttonType)
        {
          case ButtonType.MESSENGER:
            messenger.gameObject.SetActive(!messenger.gameObject.activeSelf);
            break;
          case ButtonType.PUZZLE:
            if(!_isBoxOn)
              wall.gameObject.SetActive(!wall.activeSelf);
            break;
          case ButtonType.KILLER:
            floor.SetActive(!floor.activeSelf);
            break;
        }
        if(buttonType == ButtonType.PUZZLE && _isBoxOn) return;
        _meshRenderer.material.color = color;
      }
      if (buttonType == ButtonType.PUZZLE && other.gameObject == box)
      {
        wall.gameObject.SetActive(!gameObject.activeSelf);
        
        _isBoxOn = !_isBoxOn;
        _meshRenderer.material.color = color;
        _boxMeshRenderer.material.color = color;
      }
    }
}
