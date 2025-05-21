using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    private static GameObject ControlledPlayer;

    private void Start()
    {
        var farmer = GameObject.Find("Farmer");
        if (farmer != null)
        {
            PlayerSelection.SetControlledPlayer(farmer);
        }
    }

    public static void SetControlledPlayer(GameObject player)
    {
        if (ControlledPlayer != player)
        {
            ControlledPlayer = player;
            // Debug.Log($"Active player set to: {activePlayer.name}");
        }
    }

    public static GameObject GetControlledPlayer()
    {
        return ControlledPlayer;
    }
}