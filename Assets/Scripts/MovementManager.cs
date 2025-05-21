using UnityEngine;

public class MovementManager : MonoBehaviour
{
    void Update()
    {
        if (gameObject != null && gameObject != PlayerSelection.GetActivePlayer())
        {
            PlayerController playerController = gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {

                transform.Translate(Time.deltaTime * playerController.GetSpeed(gameObject.name) * Vector3.forward);
            }
        }
    }
}
