// using UnityEngine;

// [CreateAssetMenu(fileName = "LevelData", menuName = "LaserGame/Level")]
// public class LevelData : ScriptableObject
// {
//     public int rows;
//     public int columns;

//     [Header("Laser")]
//     public Vector2 laserWorldPosition;
//     public float laserAngle;

//     [Header("Receiver")]
//     public Vector2 receiverWorldPosition;

//     [Header("Tiles")]
//     public TileInfo[] tiles;
// }

// [System.Serializable]
// public class TileInfo
// {
//     public TileType type;
//     public Vector2Int cell;
// }
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LaserGame/Level")]
public class LevelData : ScriptableObject
{
    public int rows;
    public int columns;

    [Header("Lasers")]
    public LaserInfo[] lasers;

    [Header("Receivers")]
    public ReceiverInfo[] receivers;

    [Header("Tiles")]
    public TileInfo[] tiles;
}

[System.Serializable]
public class LaserInfo
{
    public Vector2 worldPosition;   // Can be between cells
    [Range(0, 360)]
    public float angle;
}

[System.Serializable]
public class ReceiverInfo
{
    public Vector2 worldPosition;
}

[System.Serializable]
public class TileInfo
{
    public TileType type;
    public Vector2Int cell;
}

