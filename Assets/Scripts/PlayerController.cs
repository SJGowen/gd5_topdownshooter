using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
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
        // Debug.Log($"Player Name = {player.name}");
        var speed = GetSpeed(player.name);
        movement = speed * Time.deltaTime * movement.normalized;

        // Apply clamping after adjusting movement
        float horizontalPosition = Mathf.Clamp(transform.position.x + movement.x, PlayingArea.XMin, PlayingArea.XMax);
        float verticalPosition = Mathf.Clamp(transform.position.z + movement.z, PlayingArea.ZMin, PlayingArea.ZMax);

        // Update the position
        transform.position = new (horizontalPosition, 0, verticalPosition);
        transform.rotation = Quaternion.LookRotation(movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var collider = gameObject.GetComponent<Collider>();
            Vector3 frontMiddle = collider.bounds.center + (transform.forward * collider.bounds.extents.z);
            Destroy(Instantiate(projectilePrefab, frontMiddle, transform.rotation), destroyTime);
        }
    }

    void OnMouseDown()
    {
        PlayerSelection.SetActivePlayer(gameObject);
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
