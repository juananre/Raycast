using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HevyEnemy : BaseEnemy, IEnemy
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

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Enemigo recibi� da�o, salud restante: " + health);

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
