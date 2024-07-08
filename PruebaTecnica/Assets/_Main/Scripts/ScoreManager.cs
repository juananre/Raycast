using UnityEngine;

public class ScoreManager : MonoBehaviour, IObserver
{
    [SerializeField] private int pointsPerKill = 1;
    [SerializeField] private int pointsToDamagePlayer = 10;
    //[SerializeField] private Player player; // Referencia al jugador

    private int score = 0;

    public void OnEnemyDeath()
    {
        score += pointsPerKill;
        Debug.Log("Score: " + score);

        if (score >= pointsToDamagePlayer)
        {
            //DamagePlayer();
            score = 0; // Resetea el score después de quitar vida al jugador
        }
    }

    /*private void DamagePlayer()
    {
        if (player != null)
        {
            player.TakeDamage(1); // Asume que el jugador tiene un método TakeDamage(int amount)
        }
        else
        {
            Debug.LogError("Player no asignado en ScoreManager.");
        }
    }*/
}
