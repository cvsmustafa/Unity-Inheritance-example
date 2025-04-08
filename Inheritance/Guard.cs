using UnityEngine;

public class Guard : FighterNPC
{
    private GameObject enemy;

    public override void Update()
    {
        enemy = FindNearestEnemy();
        if (enemy != null)
        {
            target = enemy.transform.position;
            if (Vector3.Distance(transform.position, target) < attackRange)
            {
                PerformAction();
            }
        }
        base.MoveToTarget();
    }

    public override void PerformAction()
    {
        if (Time.time - lastAttackTime < attackCooldown) return;
        Debug.Log($"{gameObject.name} düþmana saldýrýyor");

        if (enemy != null)
        {
            Healt health = enemy.GetComponent<Healt>();
            if (health != null)
            {
                bool enemyDied = health.TakeDamage(damage);
                if (enemyDied)
                {
                    defeatedEnemy++;
                    Debug.Log($"{gameObject.name} bir düþmaný yok etti Toplam: {defeatedEnemy}");
                    TryEvolve();
                }
            }
        }
        lastAttackTime = Time.time;
    }
}
