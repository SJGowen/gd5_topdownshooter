using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float destroyTime = 2.5f;


    void Update()
    {
        GameObject controlledPlayer = PlayerSelection.GetControlledPlayer();
        if (controlledPlayer == null || gameObject != controlledPlayer) return;

        Vector3 input = new(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        var currentDirection = input.normalized;

        // Normalize the movement to ensure consistent speed in all directions
        // Debug.Log($"Player Name = {player.name}");
        MovementManager movementManager = gameObject.GetComponent<MovementManager>();
        var speed = movementManager.GetSpeed(controlledPlayer.name);
        Vector3 movement = speed * Time.deltaTime * currentDirection;

        // Apply clamping after adjusting movement
        float horizontalPosition = Mathf.Clamp(transform.position.x + movement.x, PlayingArea.XMin, PlayingArea.XMax);
        float verticalPosition = Mathf.Clamp(transform.position.z + movement.z, PlayingArea.ZMin, PlayingArea.ZMax);

        // Update the position
        transform.position = new Vector3(horizontalPosition, 0, verticalPosition);
        transform.rotation = Quaternion.LookRotation(movement);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            var collider = gameObject.GetComponent<Collider>();
            Vector3 frontMiddle = collider.bounds.center + (transform.forward * collider.bounds.extents.z);
            Destroy(Instantiate(projectilePrefab, frontMiddle, transform.rotation), destroyTime);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject != PlayerSelection.GetControlledPlayer())
            {
                // Get the contact point normal
                ContactPoint contact = collision.contacts[0];
                Vector3 normal = contact.normal;
                normal.y = 0; // Ensure the normal is 2D

                // Reflect the current direction using the collision normal
                MovementManager movementManager = GetComponent<MovementManager>();
                if (movementManager != null)
                {
                    Vector3 reflected = Vector3.Reflect(movementManager.GetDirection(), normal);
                    reflected.y = 0f; // Ensure the reflected direction is 2D
                    if (reflected != Vector3.zero)
                        movementManager.SetDirection(reflected.normalized);
                }
            }
        }
        else if (collision.gameObject.CompareTag("Projectile"))
        {
            if (gameObject != PlayerSelection.GetControlledPlayer())
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }

    void OnMouseDown()
    {
        PlayerSelection.SetControlledPlayer(gameObject);
    }
}
