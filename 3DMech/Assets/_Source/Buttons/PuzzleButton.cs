using UnityEngine;

public class PuzzleButton : ButtonAction
{
  [SerializeField] private GameObject box;
  [SerializeField] private GameObject wall;
    
  private MeshRenderer _boxMeshRenderer;
  private bool _isBoxOn;
  private LayerMask _boxLayer;
    
  protected override void Awake()
  {
    base.Awake();
    _boxMeshRenderer = box.GetComponent<MeshRenderer>();
    _boxMeshRenderer.material.color = unpressedColor;
    _boxLayer =  LayerMask.GetMask("InteractiveBox");
  }

  protected override void OnTriggerEnter(Collider other)
  {
    HandleTrigger(other, true);
  }

  protected override void OnTriggerExit(Collider other)
  {
    HandleTrigger(other, false);
  }
    
  private void HandleTrigger(Collider other, bool isEnter)
  {
    if (LayerMaskUtil.ContainsPlayer(other.gameObject))
    {
      if (!_isBoxOn)
      {
        wall.SetActive(!wall.activeSelf);
        MeshRenderer.material.color = isEnter ? pressedColor : unpressedColor;
      }
    }
    else if (LayerMaskUtil.ContainsLayer(_boxLayer,other.gameObject))
    {
      _isBoxOn = isEnter;
      wall.SetActive(!wall.activeSelf);
            
      Color newColor = isEnter ? pressedColor : unpressedColor;
      MeshRenderer.material.color = newColor;
      _boxMeshRenderer.material.color = newColor;
    }
  }
}