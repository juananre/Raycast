using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour, IObserver
{
    [SerializeField] private int pointsPerKill = 1;
    [SerializeField] TMP_Text PuntosActuales;

    private int score = 0;

    public void OnEnemyDeath()
    {
        score += pointsPerKill;

        PuntosActuales.text = score.ToString("0");
        Debug.Log("Score: " + score);
    }

}
