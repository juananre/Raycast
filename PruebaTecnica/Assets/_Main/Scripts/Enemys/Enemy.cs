using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] private int health = 10;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Enemigo recibi� da�o, salud restante: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
