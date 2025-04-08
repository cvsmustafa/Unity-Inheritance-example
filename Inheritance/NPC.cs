using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    public float speed = 5f;
    protected Vector3 target;
    public int level = 1;

    public virtual void Update()
    {
        MoveToTarget();
    }
    protected void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public abstract void PerformAction(); // her npc için özel eylem fonkiyonu
    public virtual void TryEvolve() { }  // evrim için 

}
