using UnityEngine;

public class HumanController : MonoBehaviour
{
    public float speed = 5f;
    public float xRange = 16f;
    public float zMin = 0f;
    public float zMax = 15f;
    private float horizontalInput, verticalInput;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        var horizontalPosition = Mathf.Clamp(transform.position.x + horizontalInput * speed * Time.deltaTime, xRange * -1, xRange);
        verticalInput = Input.GetAxis("Vertical");
        var verticalPosition = Mathf.Clamp(transform.position.z + verticalInput * speed * Time.deltaTime, zMin, zMax);
        transform.position = new Vector3(horizontalPosition, transform.position.y, verticalPosition);
    }
}
