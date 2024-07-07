using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : BaseEnemy, IEnemy
{
    [SerializeField] public static new int health = 2;
    [SerializeField] public static new float velocity = 5;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Enemigo recibió daño, salud restante: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Update()
    {
        if (player != null)
        {
            WalkNPC();
        }
    }
}
