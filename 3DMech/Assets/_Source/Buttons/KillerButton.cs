using UnityEngine;

public class KillerButton : ButtonAction
{
  [SerializeField] private GameObject _floor;
    
  protected override void OnTriggerEnter(Collider other)
  {
    if (LayerMaskUtil.ContainsPlayer(other.gameObject))
    {
      Press();
      _floor.SetActive(!IsPressed);
      other.TryGetComponent(out Collider component);
      component.isTrigger = true;
    }
  }

  protected override void OnTriggerExit(Collider other)
  {
    Release();
    _floor.SetActive(!IsPressed);
  }
}