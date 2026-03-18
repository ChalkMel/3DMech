using UnityEngine;

  public abstract class GetPlayerLayer : MonoBehaviour
  {
    protected LayerMask LayerMask;

    protected void Awake()
    {
      LayerMask = LayerMask.GetMask("Player");
    }
  }
