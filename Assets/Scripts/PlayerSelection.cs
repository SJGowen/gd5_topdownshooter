using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    private static GameObject activePlayer;

    public static void SetActivePlayer(GameObject player)
    {
        if (activePlayer != player)
        {
            activePlayer = player;
            // Debug.Log($"Active player set to: {activePlayer.name}");
        }
    }

    public static GameObject GetActivePlayer()
    {
        return activePlayer;
    }
}