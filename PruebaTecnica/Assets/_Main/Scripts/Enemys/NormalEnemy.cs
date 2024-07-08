using UnityEngine;

public class NormalEnemy : BaseEnemy, IEnemy
{
    [SerializeField] private new int health = 2;
    [SerializeField] private new float velocity = 5;
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

    protected override Color GetColor()
    {
        return typeEnemy;
    }

    public override void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Enemigo recibió daño, salud restante: " + health);

        if (health <= 0)
        {
            Die();
        }
    }
}