using UnityEngine;

public class StrongeEnemy : BaseEnemy, IEnemy
{
    [SerializeField] private new int health = 5;
    [SerializeField] private new float velocity = 0.7f;
    [SerializeField] private new float velocityAnimation = 2f;
    [SerializeField] private Color typeEnemy;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Enemigo recibió daño, salud restante: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    protected override Color GetColor()
    {
        return typeEnemy;
    }
}
