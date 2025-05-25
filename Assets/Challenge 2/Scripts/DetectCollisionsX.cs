using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    private ScoreManagerX scoreManagerX;

    private void Awake()
    {
        scoreManagerX = FindFirstObjectByType<ScoreManagerX>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Increment caught score for size of ball
        scoreManagerX.IncrementBallsCaught(gameObject.name);
        Destroy(gameObject);
    }
}
