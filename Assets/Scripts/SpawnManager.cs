using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animals;
    private int animalIndex;

    void Update()
    {
        GameObject player = PlayerSelection.GetControlledPlayer();
        if (player == null) return;

        animalIndex = Random.Range(0, 100);
        if (animalIndex >= 0 && animalIndex < animals.Length)
        {
            if (animals[animalIndex] != null && animals[animalIndex] != player)
            {
                Vector3 randomPosition = new(
                    Random.Range(PlayingArea.XMin, PlayingArea.XMax),
                    0,
                    Random.Range(PlayingArea.ZMin, PlayingArea.ZMax)
                );
                Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                Instantiate(animals[animalIndex], randomPosition, randomRotation);
            }
        }
    }
}
