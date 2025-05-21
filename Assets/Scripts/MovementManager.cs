using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private Vector3 currentDirection = Vector3.zero;

    public Vector3 GetDirection()
    {
        return currentDirection;
    }

    public void SetDirection(Vector3 newDirection)
    {
        if (newDirection != Vector3.zero)
            currentDirection = newDirection.normalized;
    }
    
    void Start()
    {
        if (currentDirection == Vector3.zero)
        {
            // Pick a random direction on the XZ plane
            float angle = Random.Range(0f, 360f);
            currentDirection = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
        }
    }

    void Update()
    {
        if (gameObject == null || gameObject == PlayerSelection.GetControlledPlayer()) return;

        var speed = GetSpeed(gameObject.name);
        Vector3 movement = speed * Time.deltaTime * currentDirection;
        Vector3 nextPosition = transform.position + movement;

        // Reflect from boundaries
        if (nextPosition.x < PlayingArea.XMin || nextPosition.x > PlayingArea.XMax)
        {
            currentDirection.x = -currentDirection.x;
            nextPosition.x = Mathf.Clamp(nextPosition.x, PlayingArea.XMin, PlayingArea.XMax);
        }
        if (nextPosition.z < PlayingArea.ZMin || nextPosition.z > PlayingArea.ZMax)
        {
            currentDirection.z = -currentDirection.z;
            nextPosition.z = Mathf.Clamp(nextPosition.z, PlayingArea.ZMin, PlayingArea.ZMax);
        }

        // Apply movement
        transform.position = nextPosition;
        if (currentDirection != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(currentDirection);
    }

    public float GetSpeed(string name)
    {
        if (name.IndexOf("(") > 0)
        {
            name = name[..name.IndexOf("(")];
        }

        return name switch
        {
            "Farmer" => 6f,
            "BorderCollie" => 10f,
            "Rooster" => 2f,
            "Moose" => 8f,
            _ => throw new System.Exception($"Unknown player name: {name}"),
        };
    }
}
