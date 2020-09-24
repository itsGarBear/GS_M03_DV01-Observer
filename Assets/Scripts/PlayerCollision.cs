using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public delegate void HitObstacle(Collision collisionInfo);
    public static event HitObstacle OnHitObstalce;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            OnHitObstalce?.Invoke(collision);
        }
    }
}
