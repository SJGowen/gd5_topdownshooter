using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -42;
    private float bottomLimit = -5;
    private ScoreManagerX scoreManagerX;

    private void Awake()
    {
        scoreManagerX = FindFirstObjectByType<ScoreManagerX>();
    }

    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            // Debug.Log($"Dog destruction {transform.position.x}");
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            // Debug.Log($"Ball destruction {transform.position.y}");
            // Increment missed count for size of ball
            scoreManagerX.IncrementBallsMissed(gameObject.name);

            Destroy(gameObject);
        }
    }
}
