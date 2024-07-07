using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] private int health = 10;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Enemigo recibió daño, salud restante: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
