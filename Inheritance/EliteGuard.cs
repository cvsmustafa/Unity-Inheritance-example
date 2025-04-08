using UnityEngine;

public class EliteGuard : FighterNPC
{
    private GameObject enemy;
    public override void Update()
    {
        enemy = FindNearestEnemy();
        if (enemy != null)
        {
            target = enemy.transform.position;
            if (Vector3.Distance(transform.position, target) < attackRange * 1.5)
            {
                PerformAction();
            }
        }
        base.MoveToTarget();

    }
    public override void PerformAction()
    {
        if (Time.time - lastAttackTime < attackCooldown) return;
        Debug.Log($"{gameObject.name} düþmana güçlü saldýrý yapýyor");
        if (enemy != null)
        {
            Healt health = enemy.GetComponent<Healt>();
            if (health != null)
            {
                health.TakeDamage(damage * 2);
            }
        }
        lastAttackTime = Time.time;
    }
}
