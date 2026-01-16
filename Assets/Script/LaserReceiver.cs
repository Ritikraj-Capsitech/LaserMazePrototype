// using UnityEngine;

// public class LaserReceiver : MonoBehaviour
// {
//     public bool isActivated = false;

//     public void Activate()
//     {
//         if (isActivated) return;

//         isActivated = true;
//         Debug.Log("Receiver Activated!");

//         // Visual feedback (optional)
//         // GetComponent<SpriteRenderer>().color = Color.green;

//         LevelManager.Instance.LevelComplete();
//     }
// }


// using UnityEngine;

// public class LaserReceiver : MonoBehaviour
// {
//     public bool isActivated;

//     public void Activate()
//     {
//         if (isActivated) return;
//         isActivated = true;

//         Debug.Log("Receiver Activated");

//         if (LevelManager.Instance != null)
//             LevelManager.Instance.LevelComplete();
//     }
// }

using UnityEngine;

public class LaserReceiver : MonoBehaviour
{
    public bool isActivated;

    public void Activate()
    {
        if (isActivated) return;

        isActivated = true;
        Debug.Log("Receiver Activated");

        LevelManager.Instance.CheckWinCondition();
    }
}

