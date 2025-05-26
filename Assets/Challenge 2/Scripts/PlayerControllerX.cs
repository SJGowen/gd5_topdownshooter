using TMPro;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject[] dogPrefab;
    public TMP_Dropdown dogBreed;
    public float delay = 2f;
    private float delayTime;

    void Update()
    {
        // On spacebar press, send dog
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire2")) && Time.time > delayTime)
        {
            //Debug.Log($"Time.time = {Time.time}, delayTime = {delayTime}");
            delayTime = Time.time + delay;
            Instantiate(dogPrefab[dogBreed.value], transform.position, dogPrefab[dogBreed.value].transform.rotation);
        }
    }
}

