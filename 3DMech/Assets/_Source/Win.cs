using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Win : MonoBehaviour
{
  [SerializeField] CanvasGroup WinUI;
  private void OnTriggerEnter(Collider other)
  {
    if (LayerMaskUtil.ContainsPlayer(other.gameObject))
    {
      WinUI.gameObject.SetActive(true);
    }
  }
}
