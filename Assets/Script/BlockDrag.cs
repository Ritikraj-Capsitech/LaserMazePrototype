// using UnityEngine;

// public class BlockDrag : MonoBehaviour
// {
//     private Vector3 offset;
//     private Camera cam;
//     private Vector2Int currentCell;

//     void Start()
//     {
//         cam = Camera.main;
//         SnapToClosestCell();
//     }

//     void OnMouseDown()
//     {
//         Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
//         offset = transform.position - new Vector3(mousePos.x, mousePos.y, 0);
//     }

//     void OnMouseDrag()
//     {
//         Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
//         transform.position = new Vector3(mousePos.x, mousePos.y, 0) + offset;
//     }

//     void OnMouseUp()
//     {
//         SnapToClosestCell();
//     }

//     void SnapToClosestCell()
//     {
//         float minDistance = float.MaxValue;
//         Vector2Int closestCell = Vector2Int.zero;
//         Vector3 targetPos = Vector3.zero;

//         foreach (var cell in GridManager.Instance.gridCells)
//         {
//             float dist = Vector2.Distance(transform.position, cell.Value.transform.position);

//             if (dist < minDistance)
//             {
//                 minDistance = dist;
//                 closestCell = cell.Key;
//                 targetPos = cell.Value.transform.position;
//             }
//         }

//         // Occupancy check
//         Cell targetCell = GridManager.Instance.gridCells[closestCell];

//         if (!targetCell.isOccupied || closestCell == currentCell)
//         {
//             ClearPreviousCell();
//             currentCell = closestCell;
//             targetCell.isOccupied = true;
//             transform.position = targetPos;
//         }
//         else
//         {
//             // return back
//             transform.position =
//                 GridManager.Instance.gridCells[currentCell].transform.position;
//         }
//     }

//     void ClearPreviousCell()
//     {
//         if (GridManager.Instance.gridCells.ContainsKey(currentCell))
//         {
//             GridManager.Instance.gridCells[currentCell].isOccupied = false;
//         }
//     }
// }

using UnityEngine;

public class BlockDrag : MonoBehaviour
{
    private Vector3 offset;
    private Camera cam;

    private Vector2Int currentCell;
    private bool hasCell = false;

    

    void Start()
    {
        cam = Camera.main;
        SetInitialCell();
    }

    void OnMouseDown()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, 0);
    }

    void OnMouseDrag()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0) + offset;
    }

    void OnMouseUp()
    {
        SnapToClosestCell();
    }

    void SetInitialCell()
    {
         if (GridManager.Instance == null) return;
    if (GridManager.Instance.gridCells.Count == 0) return;
        float minDist = float.MaxValue;

        foreach (var cell in GridManager.Instance.gridCells)
        {
            float dist = Vector2.Distance(transform.position, cell.Value.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                currentCell = cell.Key;
            }
        }

        GridManager.Instance.gridCells[currentCell].isOccupied = true;
        transform.position =
            GridManager.Instance.gridCells[currentCell].transform.position;

        hasCell = true;
    }

    void SnapToClosestCell()
    {
        if (!hasCell) return;

        float minDistance = float.MaxValue;
        Vector2Int closestCell = currentCell;

        foreach (var cell in GridManager.Instance.gridCells)
        {
            float dist = Vector2.Distance(transform.position, cell.Value.transform.position);

            if (dist < minDistance)
            {
                minDistance = dist;
                closestCell = cell.Key;
            }
        }

        Cell targetCell = GridManager.Instance.gridCells[closestCell];

        if (!targetCell.isOccupied || closestCell == currentCell)
        {
            GridManager.Instance.gridCells[currentCell].isOccupied = false;

            currentCell = closestCell;
            targetCell.isOccupied = true;

            transform.position = targetCell.transform.position;
        }
        else
        {
            transform.position =
                GridManager.Instance.gridCells[currentCell].transform.position;
        }
    }
}
