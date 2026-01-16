// using UnityEngine;
// using System.Collections.Generic;

// public class GridManager : MonoBehaviour
// {
//     public int rows = 4;
//     public int columns = 4;
//     public float cellSize = 1f;

//     [Header("Prefabs")]
//     public GameObject cellPrefab;
//     public GameObject blockPrefab;
//     public GameObject mirrorPrefab;

//     public static GridManager Instance;


//     public Dictionary<Vector2Int, Cell> gridCells =
//         new Dictionary<Vector2Int, Cell>();

//     void Awake()
//     {
//         Instance = this;
//         CreateGrid(); 
//     }

//     // void Awake()
//     // {
//     //     Instance = this;
//     // }

//     // void Start()
//     // {
//     //     CreateGrid();
//     // }

//     // void CreateGrid()
//     // {
//     //     float startX = -(columns - 1) * cellSize / 2f;
//     //     float startY = (rows - 1) * cellSize / 2f;

//     //     for (int y = 0; y < rows; y++)
//     //     {
//     //         for (int x = 0; x < columns; x++)
//     //         {
//     //             Vector2 position = new Vector2(
//     //                 startX + x * cellSize,
//     //                 startY - y * cellSize
//     //             );

//     //             // 1️⃣ Create Cell
//     //             GameObject cellObj = Instantiate(cellPrefab, position, Quaternion.identity);
//     //             cellObj.name = $"Cell_{x}_{y}";
//     //             cellObj.transform.parent = transform;

//     //             // 2️⃣ Register Cell
//     //             Cell cellScript = cellObj.GetComponent<Cell>();
//     //             Vector2Int gridPos = new Vector2Int(x, y);
//     //             gridCells.Add(gridPos, cellScript);

//     //             // 3️⃣ Spawn movable blocks
//     //             if ((x == 3 && y == 3) || (x == 1 && y == 4))
//     //             {
//     //                 GameObject block = Instantiate(blockPrefab, position, Quaternion.identity);
//     //                 block.transform.position = position;

//     //                 // Mark cell occupied
//     //                 // cellScript.isOccupied = true;
//     //             }

//     //             if ((x == 2 && y == 2) || (x == 4 && y == 4) || (x == 6 && y == 6))
//     //             {
//     //                 Instantiate(mirrorPrefab, position, Quaternion.identity);
//     //             }

//     //         }
//     //     }
//     // }


//     void CreateGrid()
//     {
//         gridCells.Clear();

//         float startX = -(columns - 1) * cellSize / 2f;
//         float startY = (rows - 1) * cellSize / 2f;

//         for (int y = 0; y < rows; y++)
//         {
//             for (int x = 0; x < columns; x++)
//             {
//                 Vector2 position = new Vector2(
//                     startX + x * cellSize,
//                     startY - y * cellSize
//                 );

//                 GameObject cellObj = Instantiate(cellPrefab, position, Quaternion.identity);
//                 cellObj.name = $"Cell_{x}_{y}";
//                 cellObj.transform.parent = transform;

//                 Cell cell = cellObj.GetComponent<Cell>();
//                 if (cell == null)
//                 {
//                     Debug.LogError(" Cell prefab missing Cell script");
//                     return;
//                 }

//                 gridCells.Add(new Vector2Int(x, y), cell);

//                 // 1 Spawn movable blocks
//                 if ( x == 3 && y == 3)
//                 {
//                     GameObject block = Instantiate(blockPrefab, position, Quaternion.identity);
//                     block.transform.position = position;

//                     // Mark cell occupied
//                     // cellScript.isOccupied = true;
//                 }

//                 // 3 Spawn movable mirror
//                 if ((x == 2 && y == 2) || (x == 4 && y == 4) || (x == 1 && y == 4))
//                 {
//                     Instantiate(mirrorPrefab, position, Quaternion.identity);
//                 }
//             }
//         }
//     }
// }


// using UnityEngine;
// using System.Collections.Generic;

// public class GridManager : MonoBehaviour
// {
//     public int rows = 4;
//     public int columns = 4;
//     public float cellSize = 1f;

//     public GameObject cellPrefab;
//     public GameObject blockPrefab;
//     public GameObject blockTileFixedPrefab;
//     public GameObject mirrorPrefabR;
//     public GameObject mirrorPrefabL;

//     public static GridManager Instance;

//     public Dictionary<Vector2Int, Cell> gridCells = new Dictionary<Vector2Int, Cell>();

//     void Awake()
//     {
//         Instance = this;
//         CreateGrid();
//     }

//     void CreateGrid()
//     {
//         gridCells.Clear();

//         float startX = -(columns - 1) * cellSize / 2f;
//         float startY = (rows - 1) * cellSize / 2f;

//         for (int y = 0; y < rows; y++)
//         {
//             for (int x = 0; x < columns; x++)
//             {
//                 Vector2 pos = new Vector2(startX + x * cellSize, startY - y * cellSize);

//                 GameObject cellObj = Instantiate(cellPrefab, pos, Quaternion.identity, transform);
//                 cellObj.name = $"Cell_{x}_{y}";

//                 Cell cell = cellObj.GetComponent<Cell>();
//                 gridCells.Add(new Vector2Int(x, y), cell);
//             }
//         }

//         SpawnBlock(3, 3);
//         SpawnMirrorL(1, 0);
//         SpawnMirrorR(2, 4);
//         SpawnMirrorR(3, 2);
//         SpawnBlockFixed(2,2);

//     }

//     void SpawnBlock(int x, int y)
//     {
//         Vector2Int key = new Vector2Int(x, y);
//         if (!gridCells.ContainsKey(key)) return;

//         GameObject block = Instantiate(blockPrefab, gridCells[key].transform.position, Quaternion.identity);
//         gridCells[key].isOccupied = true;
//     }

//     void SpawnBlockFixed(int x, int y)
//     {
//         Vector2Int key = new Vector2Int(x, y);
//         if (!gridCells.ContainsKey(key)) return;

//         GameObject block = Instantiate(blockTileFixedPrefab, gridCells[key].transform.position, Quaternion.identity);
//         gridCells[key].isOccupied = true;
//     }


//     void SpawnMirrorL(int x, int y)
//     {
//         Vector2Int key = new Vector2Int(x, y);
//         if (!gridCells.ContainsKey(key)) return;

//         GameObject mirror = Instantiate(mirrorPrefabL, gridCells[key].transform.position, Quaternion.identity);
//         gridCells[key].isOccupied = true;
//     }

//      void SpawnMirrorR(int x, int y)
//     {
//         Vector2Int key = new Vector2Int(x, y);
//         if (!gridCells.ContainsKey(key)) return;

//         GameObject mirror = Instantiate(mirrorPrefabR, gridCells[key].transform.position, Quaternion.identity);
//         gridCells[key].isOccupied = true;
//     }
// }


// using UnityEngine;
// using System.Collections.Generic;

// public class GridManager : MonoBehaviour
// {
//     public static GridManager Instance;

//     public int rows;
//     public int columns;
//     public float cellSize = 1f;
//     public GameObject cellPrefab;

//     public Dictionary<Vector2Int, Cell> gridCells = new Dictionary<Vector2Int, Cell>();

//     void Awake()
//     {
//         //Debug.Log("GridManager Awake called");
//         Instance = this;
//         //CreateGrid();
//     }

//     public void CreateGrid()
//     {
//         gridCells.Clear();

//         float startX = -(columns - 1) * cellSize / 2f;
//         float startY = (rows - 1) * cellSize / 2f;

//         for (int y = 0; y < rows; y++)
//         {
//             for (int x = 0; x < columns; x++)
//             {
//                 Vector2 pos = new Vector2(startX + x * cellSize, startY - y * cellSize);
//                 GameObject cellObj = Instantiate(cellPrefab, pos, Quaternion.identity, transform);
//                 cellObj.name = $"Cell_{x}_{y}";
//                 gridCells.Add(new Vector2Int(x, y), cellObj.GetComponent<Cell>());
//             }
//         }
//     }

//     public Vector3 GetCellWorldPos(Vector2Int cell)
//     {
//         return gridCells[cell].transform.position;
//     }
// }


using UnityEngine;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    public int rows;
    public int columns;
    public float cellSize = 1f;
    public GameObject cellPrefab;

    public Dictionary<Vector2Int, Cell> gridCells = new Dictionary<Vector2Int, Cell>();

    void Awake()
    {
        Instance = this;
    }

    public void CreateGrid()
    {
        gridCells.Clear();

        float startX = -(columns - 1) * cellSize / 2f;
        float startY = (rows - 1) * cellSize / 2f;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                Vector2 pos = new Vector2(
                    startX + x * cellSize,
                    startY - y * cellSize
                );

                GameObject cellObj = Instantiate(cellPrefab, pos, Quaternion.identity, transform);
                cellObj.name = $"Cell_{x}_{y}";
                gridCells.Add(new Vector2Int(x, y), cellObj.GetComponent<Cell>());
            }
        }
    }

    public Vector3 GetCellWorldPos(Vector2Int cell)
    {
        return gridCells[cell].transform.position;
    }
}
