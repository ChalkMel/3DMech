using UnityEngine;

public abstract class ButtonAction : MonoBehaviour
{
    [SerializeField] protected Color pressedColor;
    [SerializeField] protected Color unpressedColor;
    protected MeshRenderer MeshRenderer;
    protected bool IsPressed;
    
    protected virtual void Awake()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
        MeshRenderer.material.color = unpressedColor;
    }
    
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (LayerMaskUtil.ContainsPlayer(other.gameObject))
        {
            Press();
        }
    }
    
    protected virtual void OnTriggerExit(Collider other)
    {
        if (LayerMaskUtil.ContainsPlayer(other.gameObject))
        {
            Release();
        }
    }
    
    protected virtual void Press()
    {
        IsPressed = true;
        MeshRenderer.material.color = pressedColor;
    }
    
    protected virtual void Release()
    {
        IsPressed = false;
        MeshRenderer.material.color = unpressedColor;
    }
}
