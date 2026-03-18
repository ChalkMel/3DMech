using UnityEngine;

public class DangerZone : GetPlayerLayer
{
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform ResetPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMaskUtil.ContainsPlayer(other.gameObject))
        {
            GameObject newBox = Instantiate(boxPrefab, spawnPoint.position, spawnPoint.rotation);
            newBox.TryGetComponent(out MoveTrigger trigger);
            trigger.ResetPosition= ResetPoint;
            Destroy(newBox, 2f);
        }
    }
}
