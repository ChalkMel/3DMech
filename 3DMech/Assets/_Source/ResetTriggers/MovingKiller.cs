using UnityEngine;

public class MovingKiller : MoveTrigger
{
    [SerializeField] private float speed;
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, pos2.position, step);

        if (transform.position == pos2.position)
        {
            (pos1, pos2) = (pos2, pos1);
        }
    }
}
