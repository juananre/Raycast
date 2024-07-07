using UnityEngine;

public class BaseEnemy : MonoBehaviour, IEnemy
{
    protected int health = 10;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator ani;
    [SerializeField] protected float velocity = 2f;

    void Start()
    {
        if (ani == null)
        {
            ani = GetComponent<Animator>();
        }

        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    void Update()
    {
        if (player != null)
        {
            WalkNPC();
        }
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

    void WalkNPC()
    {
        Vector3 lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotacion = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 2);

        ani.SetBool("Walk", true);
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }
    protected virtual void Die()
    {
        Debug.Log("Enemigo ha muerto.");
        Destroy(gameObject);
    }
}