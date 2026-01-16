// using UnityEngine;

// public class MirrorBlock : MonoBehaviour
// {
//     public bool isSlash = true; // true = / , false = \

//     public Vector2 Reflect(Vector2 incomingDir)
//     {
//         // Normalize direction
//         incomingDir = incomingDir.normalized;

//         if (isSlash)
//         {
//             // "/" mirror
//             // Right -> Up, Down -> Left, Left -> Down, Up -> Right
//             if (incomingDir == Vector2.right) return Vector2.up;
//             if (incomingDir == Vector2.down) return Vector2.left;
//             if (incomingDir == Vector2.left) return Vector2.down;
//             if (incomingDir == Vector2.up) return Vector2.right;
//         }
//         else
//         {
//             // "\" mirror
//             // Right -> Down, Up -> Left, Left -> Up, Down -> Right
//             if (incomingDir == Vector2.right) return Vector2.down;
//             if (incomingDir == Vector2.up) return Vector2.left;
//             if (incomingDir == Vector2.left) return Vector2.up;
//             if (incomingDir == Vector2.down) return Vector2.right;
//         }

//         return Vector2.zero;
//     }
// }


// using UnityEngine;

// public class MirrorBlock : MonoBehaviour
// {
//     // true = / mirror
//     // false = \ mirror
//     public bool isSlash = true;

//     public Vector2 Reflect(Vector2 incoming)
//     {
//         incoming = incoming.normalized;

//         // "/" mirror
//         if (isSlash)
//         {
//             if (incoming == Vector2.right) return new Vector2(1, 1);     // → to ↗
//             if (incoming == Vector2.down)  return new Vector2(1, -1);   // ↓ to ↘
//             if (incoming == Vector2.left)  return new Vector2(-1, -1);  // ← to ↙
//             if (incoming == Vector2.up)    return new Vector2(-1, 1);   // ↑ to ↖

//             if (incoming == new Vector2(1, 1))   return Vector2.right;  // ↗ to →
//             if (incoming == new Vector2(1, -1))  return Vector2.down;   // ↘ to ↓
//             if (incoming == new Vector2(-1, -1)) return Vector2.left;   // ↙ to ←
//             if (incoming == new Vector2(-1, 1))  return Vector2.up;     // ↖ to ↑
//         }
//         // "\" mirror
//         else
//         {
//             if (incoming == Vector2.right) return new Vector2(1, -1);   // → to ↘
//             if (incoming == Vector2.up)    return new Vector2(1, 1);    // ↑ to ↗
//             if (incoming == Vector2.left)  return new Vector2(-1, 1);   // ← to ↖
//             if (incoming == Vector2.down)  return new Vector2(-1, -1);  // ↓ to ↙

//             if (incoming == new Vector2(1, -1))  return Vector2.right;  // ↘ to →
//             if (incoming == new Vector2(1, 1))   return Vector2.up;     // ↗ to ↑
//             if (incoming == new Vector2(-1, 1))  return Vector2.left;  // ↖ to ←
//             if (incoming == new Vector2(-1, -1)) return Vector2.down;  // ↙ to ↓
//         }

//         return Vector2.zero;
//     }
// }


// using UnityEngine;

// public class MirrorBlock : MonoBehaviour
// {
//     public bool isSlash = true; // / or \

//     public Vector2 Reflect(Vector2 incoming)
//     {
//         incoming = NormalizeToGrid(incoming);

//         if (isSlash)
//         {
//             if (incoming == Vector2.right) return new Vector2(1, 1);
//             if (incoming == Vector2.up) return new Vector2(-1, 1);
//             if (incoming == Vector2.left) return new Vector2(-1, -1);
//             if (incoming == Vector2.down) return new Vector2(1, -1);

//             if (incoming == new Vector2(1, 1)) return Vector2.right;
//             if (incoming == new Vector2(-1, 1)) return Vector2.up;
//             if (incoming == new Vector2(-1, -1)) return Vector2.left;
//             if (incoming == new Vector2(1, -1)) return Vector2.down;
//         }
//         else
//         {
//             if (incoming == Vector2.right) return new Vector2(1, -1);
//             if (incoming == Vector2.down) return new Vector2(-1, -1);
//             if (incoming == Vector2.left) return new Vector2(-1, 1);
//             if (incoming == Vector2.up) return new Vector2(1, 1);

//             if (incoming == new Vector2(1, -1)) return Vector2.right;
//             if (incoming == new Vector2(-1, -1)) return Vector2.down;
//             if (incoming == new Vector2(-1, 1)) return Vector2.left;
//             if (incoming == new Vector2(1, 1)) return Vector2.up;
//         }

//         return Vector2.zero;
//     }

//     Vector2 NormalizeToGrid(Vector2 dir)
//     {
//         dir = dir.normalized;
//         return new Vector2(Mathf.Round(dir.x), Mathf.Round(dir.y));
//     }
// }


// using UnityEngine;

// public class MirrorBlock : MonoBehaviour
// {
//     // true = / , false = \
//     public bool isSlash = true;

//     public Vector2 Reflect(Vector2 incoming)
//     {
//         incoming = new Vector2(
//             Mathf.Round(incoming.x),
//             Mathf.Round(incoming.y)
//         );

//         // "/" mirror
//         if (isSlash)
//         {
//             if (incoming == Vector2.right) return new Vector2(1, 1);
//             if (incoming == Vector2.up) return new Vector2(-1, 1);
//             if (incoming == Vector2.left) return new Vector2(-1, -1);
//             if (incoming == Vector2.down) return new Vector2(1, -1);

//             if (incoming == new Vector2(1, 1)) return Vector2.right;
//             if (incoming == new Vector2(-1, 1)) return Vector2.up;
//             if (incoming == new Vector2(-1, -1)) return Vector2.left;
//             if (incoming == new Vector2(1, -1)) return Vector2.down;
//         }
//         // "\" mirror
//         else
//         {
//             if (incoming == Vector2.right) return new Vector2(1, -1);
//             if (incoming == Vector2.down) return new Vector2(-1, -1);
//             if (incoming == Vector2.left) return new Vector2(-1, 1);
//             if (incoming == Vector2.up) return new Vector2(1, 1);

//             if (incoming == new Vector2(1, -1)) return Vector2.right;
//             if (incoming == new Vector2(-1, -1)) return Vector2.down;
//             if (incoming == new Vector2(-1, 1)) return Vector2.left;
//             if (incoming == new Vector2(1, 1)) return Vector2.up;
//         }

//         return Vector2.zero;
//     }
// }


// using UnityEngine;

// public class MirrorBlock : MonoBehaviour
// {
//     public enum MirrorType
//     {
//         Slash,      // /
//         BackSlash  // \
//     }

//     public MirrorType mirrorType;

//     public Vector2 Reflect(Vector2 incoming)
//     {
//         incoming = SnapDirection(incoming);

//         if (mirrorType == MirrorType.Slash)
//         {
//             // / mirror
//             return new Vector2(incoming.y, incoming.x);
//         }
//         else
//         {
//             // \ mirror
//             return new Vector2(-incoming.y, -incoming.x);
//         }
//     }

//     Vector2 SnapDirection(Vector2 dir)
//     {
//         dir = dir.normalized;

//         Vector2[] allowed =
//         {
//             Vector2.right,
//             Vector2.left,
//             Vector2.up,
//             Vector2.down,
//             new Vector2(1,1).normalized,
//             new Vector2(1,-1).normalized,
//             new Vector2(-1,1).normalized,
//             new Vector2(-1,-1).normalized
//         };

//         float best = -1;
//         Vector2 bestDir = Vector2.right;

//         foreach (var d in allowed)
//         {
//             float dot = Vector2.Dot(dir, d);
//             if (dot > best)
//             {
//                 best = dot;
//                 bestDir = d;
//             }
//         }

//         return bestDir;
//     }
// }


// using UnityEngine;

// public class MirrorBlock : MonoBehaviour
// {

//     public enum LaserDir
// {
//     Right,
//     Left,
//     Up,
//     Down,
//     UpRight,
//     UpLeft,
//     DownRight,
//     DownLeft
// }

//     public enum MirrorType
//     {
//         Slash,      // /
//         BackSlash   // \
//     }

//     public MirrorType mirrorType;

//     public Vector2 Reflect(Vector2 incoming)
//     {
//         incoming = Snap(incoming);

//         if (mirrorType == MirrorType.Slash)
//         {
//             if (incoming == Vector2.right) return new Vector2(1, 1);
//             if (incoming == Vector2.down)  return new Vector2(-1, -1);
//             if (incoming == Vector2.left)  return new Vector2(-1, 1);
//             if (incoming == Vector2.up)    return new Vector2(1, -1);
//         }
//         else // BackSlash
//         {
//             if (incoming == Vector2.right) return new Vector2(1, -1);
//             if (incoming == Vector2.up)    return new Vector2(1, 1);
//             if (incoming == Vector2.left)  return new Vector2(-1, -1);
//             if (incoming == Vector2.down)  return new Vector2(-1, 1);
//         }

//         return Vector2.zero;
//     }

//     Vector2 Snap(Vector2 dir)
//     {
//         if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
//             return dir.x > 0 ? Vector2.right : Vector2.left;
//         else
//             return dir.y > 0 ? Vector2.up : Vector2.down;
//     }
// }

using UnityEngine;

public class MirrorBlock : MonoBehaviour
{
    public bool turnRight = true;

    public Vector2 Reflect(Vector2 incoming)
    {
        return turnRight
            ? new Vector2(incoming.y, -incoming.x)
            : new Vector2(-incoming.y, incoming.x);
    }
}

// using UnityEngine;

// public class MirrorBlock : MonoBehaviour
// {
//     public Vector2 Reflect(Vector2 incoming)
//     {
//         incoming = incoming.normalized;

//         // Mirror normal based on its rotation
//         Vector2 normal = transform.up.normalized;

//         // Reflect incoming direction using physics reflection
//         Vector2 reflected = Vector2.Reflect(incoming, normal);

//         return reflected.normalized;
//     }
// }




// using UnityEngine;

// public class MirrorBlock : MonoBehaviour
// {
//     public bool turnRight = true; 

//     public Vector2 Reflect(Vector2 incoming)
//     {
//         incoming = incoming.normalized;

//         return turnRight
//             ? Rotate90CW(incoming)
//             : Rotate90CCW(incoming);
//     }

//     Vector2 Rotate90CW(Vector2 v)
//     {
//         // (x, y) → (y, -x)
//         return new Vector2(v.y, -v.x);
//     }

//     Vector2 Rotate90CCW(Vector2 v)
//     {
//         // (x, y) → (-y, x)
//         return new Vector2(-v.y, v.x);
//     }
// }

// using UnityEngine;

// public class MirrorBlock : MonoBehaviour
// {
//     // true = "/" mirror
//     // false = "\" mirror
//     public bool isSlash = true;

//     public Vector2 Reflect(Vector2 incoming)
//     {
//         incoming = incoming.normalized;

//         // Slash mirror: /
//         if (isSlash)
//         {
//             if (incoming == new Vector2(1, 1).normalized)   return Vector2.left;
//             if (incoming == new Vector2(-1, -1).normalized) return Vector2.right;
//             if (incoming == new Vector2(1, -1).normalized)  return Vector2.up;
//             if (incoming == new Vector2(-1, 1).normalized)  return Vector2.down;
//         }
//         // Backslash mirror: \
//         else
//         {
//             if (incoming == new Vector2(1, 1).normalized)   return Vector2.down;
//             if (incoming == new Vector2(-1, -1).normalized) return Vector2.up;
//             if (incoming == new Vector2(1, -1).normalized)  return Vector2.left;
//             if (incoming == new Vector2(-1, 1).normalized)  return Vector2.right;
//         }

//         return Vector2.zero;
//     }
// }

