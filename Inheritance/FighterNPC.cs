using UnityEngine;

public abstract class FighterNPC : NPC
{
    public float attackRange = 2f;
    public int damage = 5;
    protected int defeatedEnemy;

    protected float lastAttackTime;
    public float attackCooldown = 1f;

    protected GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearest = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = enemy;
            }
        }
        return nearest;
    }

    public override void TryEvolve()
    {
        if (defeatedEnemy >= 5 && level == 1)
        {
            EvolveToEliteGuard();
        }

    }

    private void EvolveToEliteGuard()
    {
        Debug.Log($"{gameObject.name} savaþçý evriliyor!");

        var renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.yellow;
        }

        Destroy(this);
        gameObject.AddComponent<EliteGuard>();
    }
}