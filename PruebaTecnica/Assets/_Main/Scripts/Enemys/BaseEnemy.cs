using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected int health = 10;
    [SerializeField] protected GameObject player;
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

    protected void WalkNPC()
    {
        Vector3 lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotacion = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 2);

        ani.SetBool("Walk", true);
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }

    protected void Die()
    {
        Debug.Log("Enemigo ha muerto.");
        Destroy(gameObject);
    }
}