using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour, IEnemy
{
    [SerializeField] private int health = 10;
    [SerializeField] TMP_Text VidaActual;

    public void Update()
    {
        VidaActual.text = health.ToString("0");
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Jugador recibió daño, salud restante: " + health);

        if (health <= 0)
        {
            Debug.Log("Jugador ha muerto.");
            // lógica para cuando el jugador muere
        }
    }
}
