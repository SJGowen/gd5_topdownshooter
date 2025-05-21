using UnityEngine;

public class PlayingArea : MonoBehaviour
{
    private static float xMin = -23.8f;
    private static float xMax = 23.8f;
    private static float zMin = -14.4f;
    private static float zMax = 34.2f;

    public static float XMin { get => xMin; set => xMin = value; }
    public static float XMax { get => xMax; set => xMax = value; }
    public static float ZMin { get => zMin; set => zMin = value; }
    public static float ZMax { get => zMax; set => zMax = value; }
}
