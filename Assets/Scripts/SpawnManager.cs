using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animals;
    private int animalIndex;

    void Update()
    {
        GameObject player = PlayerSelection.GetActivePlayer();
        if (player == null) return;

        animalIndex = Random.Range(0, 100);
        if (animalIndex >= 0 && animalIndex <= animals.Length)
        {
            if (animals[animalIndex] != null && animals[animalIndex] != player)
            {
                Vector3 randomPosition = new(
                    Random.Range(-23.8f, 23.8f),
                    0,
                    Random.Range(-14.4f, 34.2f)
                );
                Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                Instantiate(animals[animalIndex], randomPosition, randomRotation);
            }
        }
    }
}
