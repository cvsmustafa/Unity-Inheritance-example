using UnityEngine;

public class Collector : WorkerNPC
{
    public Transform[] resourcePoints;
    private int currentPointIndex = 0;

    public override void Update()
    {
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % resourcePoints.Length;
            target = resourcePoints[currentPointIndex].position;
            AddResource(2);
        }
        base.MoveToTarget();
    }

    public override void PerformAction()
    {
        Debug.Log($"{gameObject.name} kaynak topluyor");
    }
    private void Start()
    {
        target = resourcePoints[0].position;
    }
}
