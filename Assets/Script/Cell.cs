using UnityEngine;

public enum CellType
{
    Empty,
    Block,
    Source,
    Target
}

public class Cell : MonoBehaviour
{
    public CellType cellType = CellType.Empty;

    public bool isOccupied;

}
