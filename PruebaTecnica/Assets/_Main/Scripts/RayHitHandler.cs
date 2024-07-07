using UnityEngine;

public class RayHitHandler : MonoBehaviour, IRayHitHandler
{
    public void HandleRayHit(RaycastHit hit)
    {
        var enemy = hit.transform.GetComponent<IEnemy>();
        if (enemy != null)
        {
            Debug.Log("Hitting enemy: " + hit.transform.name);
            enemy.TakeDamage(1);
        }
        else
        {
            Debug.Log("Raycast hit an object without IEnemy component: " + hit.transform.name);
        }
    }
}
