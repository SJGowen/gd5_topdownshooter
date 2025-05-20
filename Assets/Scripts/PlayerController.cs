using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float xMin = -23.8f;
    public float xMax = 23.8f;
    public float zMin = -14.4f;
    public float zMax = 34.2f;
    public float destroyTime = 2.5f;
    

    void Start()
    {
        
    }

    void Update()
    {
        GameObject player = PlayerSelection.GetActivePlayer();
        if (player == null || gameObject != player) return;

        Vector3 movement = new (Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        // Normalize the movement to ensure consistent speed in all directions
        Debug.Log($"Player Name = {player.name}");
        var speed = GetSpeed(player.name);
        movement = speed * Time.deltaTime * movement.normalized;

        // Apply clamping after adjusting movement
        float horizontalPosition = Mathf.Clamp(transform.position.x + movement.x, xMin, xMax);
        float verticalPosition = Mathf.Clamp(transform.position.z + movement.z, zMin, zMax);

        // Update the position
        transform.position = new (horizontalPosition, 0, verticalPosition);
        transform.rotation = Quaternion.LookRotation(movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(Instantiate(projectilePrefab, transform.position, transform.rotation), destroyTime);
        }
    }

    void OnMouseDown()
    {
        PlayerSelection.SetActivePlayer(gameObject);
    }

    private float GetSpeed(string name)
    {
        switch (name)
        {
            case "Farmer":
                return 6f;
            case "BorderCollie":
                return 6f;
            case "Rooster":
                return 2f;
            case "Moose":
                return 8f;
            default:
                return 6f;
            }
        }
}
