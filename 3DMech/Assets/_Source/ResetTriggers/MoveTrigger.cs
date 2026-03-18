using UnityEngine;

public abstract class MoveTrigger : MonoBehaviour
{
    [SerializeField] public Transform ResetPosition;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (LayerMaskUtil.ContainsPlayer(other.gameObject))
        {
            other.transform.position = ResetPosition.position;
            other.TryGetComponent(out Collider component);
            if (component.isTrigger)
                component.isTrigger = false;
        }
    }
}
