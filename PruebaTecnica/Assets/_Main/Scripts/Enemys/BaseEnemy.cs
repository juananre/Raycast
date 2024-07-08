using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public abstract class BaseEnemy : MonoBehaviour, ISubject
{
    private List<IObserver> observers = new List<IObserver>();

    protected int health = 1;
    [SerializeField] protected GameObject player;
    [SerializeField] protected Animator ani;
    [SerializeField] protected Renderer meshColor;
    protected float velocity = 0.7f;
    protected float velocityAnimation = 2f;

    protected virtual void Start()
    {
        if (ani == null)
        {
            ani = GetComponent<Animator>();
            if (ani == null)
            {
                Debug.LogError("Animator no encontrado.");
            }
        }

        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
            if (player == null)
            {
                Debug.LogError("Player no encontrado.");
            }
        }

        if (meshColor == null)
        {
            meshColor = GetComponentInChildren<Renderer>();
            if (meshColor == null)
            {
                Debug.LogError("Renderer no encontrado.");
            }
        }

        StartCoroutine(ColorBody());
    }

    protected virtual void Update()
    {
        if (player != null)
        {
            WalkNPC();
        }
    }

    protected void WalkNPC()
    {
        Vector3 lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotacion = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 2);

        if (ani != null)
        {
            ani.speed = velocityAnimation;
            ani.SetBool("Walk", true);
        }
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }

    protected void Die()
    {
        NotifyObservers();
        Debug.Log("Enemigo ha muerto.");
        Destroy(gameObject);
    }

    protected void Attack()
    {
        
        Debug.Log("Enemigo ha muerto.");
        Destroy(gameObject);
    }

    protected IEnumerator ColorBody()
    {
        if (meshColor != null)
        {
            meshColor.material.color = GetColor();
        }
        yield return new WaitForSeconds(0.5f);
    }

    protected abstract Color GetColor();

    public abstract void TakeDamage(int amount);

    public void RegisterObserver(IObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void UnregisterObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnEnemyDeath();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player playerComponent = collision.gameObject.GetComponent<Player>();
            if (playerComponent != null)
            {
                playerComponent.TakeDamage(1);
                Attack();
            }
        }
    }
}