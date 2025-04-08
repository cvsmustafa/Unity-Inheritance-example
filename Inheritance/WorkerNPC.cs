using UnityEngine;

public abstract class WorkerNPC : NPC
{
    protected int resourceCount = 0;
    public void AddResource(int amount)
    {
        resourceCount += amount;
        Debug.Log($"{gameObject.name} topladý. Toplam kaynak: {resourceCount}");
        TryEvolve();
    }

    public override void TryEvolve()
    {
        if (resourceCount >= 10 && level == 1)
        {
            EvolveToFighter();
        }
    }

    private void EvolveToFighter()
    {
        Debug.Log($"{gameObject.name} evriliyor!");

        // Rengi yeþile çevir
        var renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.green;
        }

        Destroy(this);
        gameObject.AddComponent<Guard>();
    }
}
