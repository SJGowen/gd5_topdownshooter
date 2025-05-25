using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float delay = 2f;
    private float delayTime;

    void Update()
    {
        // On spacebar press, send dog
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")) && Time.time > delayTime)
        {
            //Debug.Log($"Time.time = {Time.time}, delayTime = {delayTime}");
            delayTime = Time.time + delay;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}

