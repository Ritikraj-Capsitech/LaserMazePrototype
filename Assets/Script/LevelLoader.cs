// using UnityEngine;

// public class LevelLoader : MonoBehaviour
// {
//     public GridManager grid;

//     [Header("Prefabs")]
//     public GameObject blockPrefab;
//     public GameObject blockFixedPrefab;
//     public GameObject mirrorLPrefab;
//     public GameObject mirrorRPrefab;
//     public GameObject laserEmitterPrefab;
//     public GameObject laserReceiverPrefab;

//     public LevelData level;

//     void Start()
//     {
//         LoadLevel(level);
//     }

//     public void LoadLevel(LevelData data)
//     {
//         grid.rows = data.rows;
//         grid.columns = data.columns;
//         grid.CreateGrid();

//         // Laser
//         GameObject laser = Instantiate(laserEmitterPrefab, data.laserWorldPosition, Quaternion.identity);
//         laser.GetComponent<LaserEmitter>().startAngle = data.laserAngle;

//         // Receiver
//         Instantiate(laserReceiverPrefab, data.receiverWorldPosition, Quaternion.identity);

//         // Tiles
//         foreach (var t in data.tiles)
//         {
//             Vector3 pos = grid.GetCellWorldPos(t.cell);

//             switch (t.type)
//             {
//                 case TileType.Block:
//                     Instantiate(blockPrefab, pos, Quaternion.identity);
//                     break;

//                 case TileType.BlockFixed:
//                     Instantiate(blockFixedPrefab, pos, Quaternion.identity);
//                     break;

//                 case TileType.MirrorL:
//                     Instantiate(mirrorLPrefab, pos, Quaternion.identity);
//                     break;

//                 case TileType.MirrorR:
//                     Instantiate(mirrorRPrefab, pos, Quaternion.identity);
//                     break;
//             }

//             grid.gridCells[t.cell].isOccupied = true;
//         }
//     }
// }



// using UnityEngine;

// public class LevelLoader : MonoBehaviour
// {
//     public GridManager grid;

//     [Header("Level List")]
//     public LevelData[] levels;
//     public int currentLevelIndex;

//     [Header("Prefabs")]
//     public GameObject blockPrefab;
//     public GameObject blockFixedPrefab;
//     public GameObject mirrorLPrefab;
//     public GameObject mirrorRPrefab;
//     public GameObject laserEmitterPrefab;
//     public GameObject laserReceiverPrefab;

//     GameObject currentLaser;
//     GameObject currentReceiver;

//     void Start()
//     {
//         LoadLevel(currentLevelIndex);
//     }

//     public void LoadLevel(int index)
//     {
//         ClearLevel();

//         LevelData data = levels[index];

//         grid.rows = data.rows;
//         grid.columns = data.columns;
//         grid.CreateGrid();

//         // Laser
//         currentLaser = Instantiate(
//             laserEmitterPrefab,
//             data.laserWorldPosition,
//             Quaternion.identity
//         );
//         currentLaser.GetComponent<LaserEmitter>().startAngle = data.laserAngle;

//         // Receiver
//         currentReceiver = Instantiate(
//             laserReceiverPrefab,
//             data.receiverWorldPosition,
//             Quaternion.identity
//         );

//         // Tiles
//         foreach (var t in data.tiles)
//         {
//             Vector3 pos = grid.GetCellWorldPos(t.cell);

//             GameObject obj = null;

//             switch (t.type)
//             {
//                 case TileType.Block:
//                     obj = Instantiate(blockPrefab, pos, Quaternion.identity);
//                     break;

//                 case TileType.BlockFixed:
//                     obj = Instantiate(blockFixedPrefab, pos, Quaternion.identity);
//                     break;

//                 case TileType.MirrorL:
//                     obj = Instantiate(mirrorLPrefab, pos, Quaternion.identity);
//                     break;

//                 case TileType.MirrorR:
//                     obj = Instantiate(mirrorRPrefab, pos, Quaternion.identity);
//                     break;
//             }

//             grid.gridCells[t.cell].isOccupied = true;
//         }
//     }

//     void ClearLevel()
//     {
//         foreach (Transform child in grid.transform)
//             Destroy(child.gameObject);

//         if (currentLaser) Destroy(currentLaser);
//         if (currentReceiver) Destroy(currentReceiver);

//         grid.gridCells.Clear();
//     }

//     public void LoadNextLevel()
//     {
//         currentLevelIndex++;

//         if (currentLevelIndex >= levels.Length)
//         {
//             Debug.Log("ALL LEVELS COMPLETE");
//             return;
//         }

//         LoadLevel(currentLevelIndex);
//     }

//     public void RetryLevel()
//     {
//         LoadLevel(currentLevelIndex);
//     }
// }

using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public GridManager grid;

    [Header("Prefabs")]
    public GameObject blockPrefab;
    public GameObject blockFixedPrefab;
    public GameObject mirrorLPrefab;
    public GameObject mirrorRPrefab;
    public GameObject laserEmitterPrefab;
    public GameObject laserReceiverPrefab;

    [Header("Levels")]
    public LevelData[] levels;   // ⭐ MULTIPLE LEVELS
    public int currentLevelIndex = 0;

    void Start()
    {
        LoadCurrentLevel();
    }

    public void LoadCurrentLevel()
    {
        LoadLevel(levels[currentLevelIndex]);
    }

    public void LoadNextLevel()
    {
        currentLevelIndex++;

        if (currentLevelIndex >= levels.Length)
        {
            Debug.Log("🎉 ALL LEVELS COMPLETED");
            return;
        }

        LoadCurrentLevel();
    }

    void ClearScene()
{
    foreach (Transform child in grid.transform)
        Destroy(child.gameObject);

    foreach (var l in FindObjectsByType<LaserEmitter>(FindObjectsSortMode.None))
        Destroy(l.gameObject);

    foreach (var r in FindObjectsByType<LaserReceiver>(FindObjectsSortMode.None))
        Destroy(r.gameObject);

    foreach (var b in FindObjectsByType<BlockDrag>(FindObjectsSortMode.None))
        Destroy(b.gameObject);

    foreach (var m in FindObjectsByType<MirrorBlock>(FindObjectsSortMode.None))
        Destroy(m.gameObject);
}


    void LoadLevel(LevelData data)
    {
        ClearScene();

        grid.rows = data.rows;
        grid.columns = data.columns;
        grid.CreateGrid();

        // ===== LASERS =====
        foreach (var laser in data.lasers)
        {
            GameObject l = Instantiate(
                laserEmitterPrefab,
                laser.worldPosition,
                Quaternion.identity
            );
            l.GetComponent<LaserEmitter>().startAngle = laser.angle;
        }

        // ===== RECEIVERS =====
        foreach (var receiver in data.receivers)
        {
            Instantiate(
                laserReceiverPrefab,
                receiver.worldPosition,
                Quaternion.identity
            );
        }

        // ===== TILES =====
        foreach (var t in data.tiles)
        {
            Vector3 pos = grid.GetCellWorldPos(t.cell);

            switch (t.type)
            {
                case TileType.Block:
                    Instantiate(blockPrefab, pos, Quaternion.identity);
                    break;

                case TileType.BlockFixed:
                    Instantiate(blockFixedPrefab, pos, Quaternion.identity);
                    break;

                case TileType.MirrorL:
                    Instantiate(mirrorLPrefab, pos, Quaternion.identity);
                    break;

                case TileType.MirrorR:
                    Instantiate(mirrorRPrefab, pos, Quaternion.identity);
                    break;
            }

            grid.gridCells[t.cell].isOccupied = true;
        }
    }
}
