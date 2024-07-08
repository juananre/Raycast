using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    private protected int health = 1;
    private protected float velocity = 0.7f;
    private protected float velocityAnimation = 2f;
    [SerializeField] protected GameObject player;
    [SerializeField] protected Animator ani;
    [SerializeField] protected Renderer meshColor;

    

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

        ani.speed = velocityAnimation;
        ani.SetBool("Walk", true);
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }

    protected void Die()
    {
        Debug.Log("Enemigo ha muerto.");
        Destroy(gameObject);
    }

    protected IEnumerator ColorBody()
    {
        if (meshColor == null)
        {
            meshColor = GetComponentInChildren<Renderer>();
        }

        meshColor.material.color = GetColor();

        yield return new WaitForSeconds(0.5f);
    }

    protected abstract Color GetColor();
}
