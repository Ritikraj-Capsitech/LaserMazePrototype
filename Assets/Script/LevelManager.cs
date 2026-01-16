// using UnityEngine;

// public class LevelManager : MonoBehaviour
// {
//     public static LevelManager Instance;

//     void Awake()
//     {
//         if (Instance == null) Instance = this;
//         else Destroy(gameObject);
//     }

//     public void LevelComplete()
//     {
//         Debug.Log(" LEVEL COMPLETE");

//         // Pause laser updates or input
//         //Time.timeScale = 0f;

//         // Show UI later
//     }
// }



// using UnityEngine;

// public class LevelManager : MonoBehaviour
// {
//     public static LevelManager Instance;
//     public LevelLoader levelLoader;

//     void Awake()
//     {
//         if (Instance == null) Instance = this;
//         else Destroy(gameObject);
//     }

//     public void LevelComplete()
//     {
//         Debug.Log("LEVEL COMPLETE");
//         Invoke(nameof(Next), 0.5f);
//     }

//     void Next()
//     {
//         levelLoader.LoadNextLevel();
//     }
// }

using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public LevelLoader levelLoader;

    public GameObject NextLevelUi;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void CheckWinCondition()
    {
        LaserReceiver[] receivers =  FindObjectsByType<LaserReceiver>(FindObjectsSortMode.None);
        foreach (var r in receivers)
        {
            if (!r.isActivated)
                return;
        }
        NextLevelUi.SetActive(true);
        //LevelComplete();
    }

    public void LevelComplete()
    {
        Debug.Log("✅ LEVEL COMPLETE");
        levelLoader.LoadNextLevel();
        NextLevelUi.SetActive(false);
    }
}
