// using UnityEngine;

// public class LaserEmitter : MonoBehaviour
// {
//     public float maxDistance = 20f;
//     public Vector2 direction = Vector2.right;

//     private LineRenderer line;

//     void Start()
//     {
//         line = GetComponent<LineRenderer>();
//         FireLaser();
//     }

//     void Update()
//     {
//         FireLaser();
//     }

//     void FireLaser()
//     {
//         Vector2 start = transform.position;
//         //RaycastHit2D hit = Physics2D.Raycast(start, direction, maxDistance);
//         RaycastHit2D hit = Physics2D.Raycast(
//     start,
//     direction,
//     maxDistance,
//     LayerMask.GetMask("Block")
// );


//         line.SetPosition(0, start);

//         if (hit.collider != null)
//         {
//             line.SetPosition(1, hit.point);
//         }
//         else
//         {
//             line.SetPosition(1, start + direction * maxDistance);
//         }

        
//     }
// }


// using UnityEngine;
// using System.Collections.Generic;

// public class LaserEmitter : MonoBehaviour
// {
//     public float maxDistance = 20f;
//     public Vector2 startDirection = new Vector2(1, 0);
//     public int maxReflections = 10;

//     private LineRenderer line;

//     //public Vector2 startDirection = new Vector2(1, 0); // →


//     void Start()
//     {
//         line = GetComponent<LineRenderer>();
//     }

//     void Update()
//     {
//         FireLaser();
//     }

//     void FireLaser()
//     {
//         List<Vector3> points = new List<Vector3>();

//         Vector2 currentPos = transform.position;
//         Vector2 currentDir = startDirection;

        


//         points.Add(currentPos);

//         for (int i = 0; i < maxReflections; i++)
//         {
//             RaycastHit2D hit = Physics2D.Raycast(
//                 currentPos,
//                 currentDir.normalized,
//                 maxDistance
//             );

//             if (hit.collider == null)
//             {
//                 points.Add(currentPos + currentDir * maxDistance);
//                 break;
//             }

//             points.Add(hit.point);

//             MirrorBlock mirror = hit.collider.GetComponent<MirrorBlock>();

//             if (mirror != null)
//             {
//                 // Reflect laser
//                 currentDir = mirror.Reflect(currentDir).normalized;
//                 currentPos = hit.point + currentDir * 0.01f; // small offset
//             }
//             else
//             {
//                 // Hit normal block → stop
//                 break;
//             }
//         }

//         line.positionCount = points.Count;
//         line.SetPositions(points.ToArray());
//     }

//     Vector2 SnapDirection(Vector2 dir)
// {
//     dir = dir.normalized;

//     Vector2[] allowed =
//     {
//         Vector2.right,
//         Vector2.left,
//         Vector2.up,
//         Vector2.down,
//         new Vector2(1, 1).normalized,
//         new Vector2(1, -1).normalized,
//         new Vector2(-1, 1).normalized,
//         new Vector2(-1, -1).normalized
//     };

//     float bestDot = -1f;
//     Vector2 bestDir = Vector2.right;

//     foreach (var d in allowed)
//     {
//         float dot = Vector2.Dot(dir, d);
//         if (dot > bestDot)
//         {
//             bestDot = dot;
//             bestDir = d;
//         }
//     }

//     return bestDir;
// }

// }


// using UnityEngine;
// using System.Collections.Generic;

// public class LaserEmitter : MonoBehaviour
// {
//     public float maxDistance = 20f;
//     public Vector2 startDirection = Vector2.right;
//     public int maxReflections = 10;

//     private LineRenderer line;

//     void Start()
//     {
//         line = GetComponent<LineRenderer>();
//     }

//     void Update()
//     {
//         FireLaser();
//     }

//     void FireLaser()
//     {
//         List<Vector3> points = new List<Vector3>();

//         Vector2 currentPos = transform.position;
//         Vector2 currentDir = SnapDirection(startDirection);

//         points.Add(currentPos);

//         for (int i = 0; i < maxReflections; i++)
//         {
//             RaycastHit2D hit = Physics2D.Raycast(
//                 currentPos,
//                 currentDir,
//                 maxDistance,
//                 LayerMask.GetMask("Block", "Mirror")
//             );

//             if (hit.collider == null)
//             {
//                 points.Add(currentPos + currentDir * maxDistance);
//                 break;
//             }

//             points.Add(hit.point);

//             MirrorBlock mirror = hit.collider.GetComponent<MirrorBlock>();

//             if (mirror != null)
//             {
//                 // ✅ SNAP REFLECTION TO 8-DIRECTION GRID
//                 currentDir = SnapDirection(mirror.Reflect(currentDir));

//                 // ✅ OFFSET TO PREVENT SELF-HIT
//                 currentPos = hit.point + currentDir * 0.05f;
//             }
//             else
//             {
//                 // Hit solid block
//                 break;
//             }
//         }

//         line.positionCount = points.Count;
//         line.SetPositions(points.ToArray());
//     }

//     // 🔒 Locks laser direction to 45° grid
//     Vector2 SnapDirection(Vector2 dir)
//     {
//         dir = dir.normalized;

//         Vector2[] allowed =
//         {
//             Vector2.right,
//             Vector2.left,
//             Vector2.up,
//             Vector2.down,
//             new Vector2(1, 1).normalized,
//             new Vector2(1, -1).normalized,
//             new Vector2(-1, 1).normalized,
//             new Vector2(-1, -1).normalized
//         };

//         float bestDot = -1f;
//         Vector2 bestDir = Vector2.right;

//         foreach (var d in allowed)
//         {
//             float dot = Vector2.Dot(dir, d);
//             if (dot > bestDot)
//             {
//                 bestDot = dot;
//                 bestDir = d;
//             }
//         }

//         return bestDir;
//     }
// }



// using UnityEngine;
// using System.Collections.Generic;

// [RequireComponent(typeof(LineRenderer))]
// public class LaserEmitter : MonoBehaviour
// {
//     public float maxDistance = 20f;
//     //public Vector2 startDirection = Vector2.right;
//     [Range(0, 360)]
//     public float startAngle = 45f;


//     public int maxReflections = 10;

//     LineRenderer line;

//     void Awake()
//     {
//         line = GetComponent<LineRenderer>();
//     }

//     void Update()
//     {
//         FireLaser();
//     }

//     Vector2 AngleToDirection(float angle)
// {
//     float rad = angle * Mathf.Deg2Rad;
//     return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;
// }

//     void FireLaser()
//     {
//         List<Vector3> points = new List<Vector3>();

//         Vector2 pos = transform.position;
//         Vector2 currentDir = AngleToDirection(startAngle);
//        // Vector2 dir = SnapDirection(startDirection);

//         points.Add(pos);

//         for (int i = 0; i < maxReflections; i++)
//         {
//             RaycastHit2D hit = Physics2D.Raycast(pos, currentDir, maxDistance);

//             if (!hit)
//             {
//                 points.Add(pos + currentDir * maxDistance);
//                 break;
//             }

//             points.Add(hit.point);

//             MirrorBlock mirror = hit.collider.GetComponent<MirrorBlock>();

//             if (mirror != null)
//             {
//                 currentDir = SnapDirection(mirror.Reflect(currentDir));
//                 pos = hit.point + currentDir * 0.02f;
//             }
//             // else
//             // {
//             //     break;
//             // }

//             else
// {
//     LaserReceiver receiver = hit.collider.GetComponent<LaserReceiver>();

//     if (receiver != null)
//     {
//         receiver.Activate();
//     }

//     break;
// }
//         }

//         line.positionCount = points.Count;
//         line.SetPositions(points.ToArray());
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


using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class LaserEmitter : MonoBehaviour
{
    public float maxDistance = 20f;
    [Range(0, 360)] public float startAngle = 45f;
    public int maxReflections = 10;

    LineRenderer line;
    bool stopLaser;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (!stopLaser)
            FireLaser();
    }

    Vector2 DirFromAngle(float angle)
    {
        float r = angle * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(r), Mathf.Sin(r)).normalized;
    }

    void FireLaser()
    {
        List<Vector3> pts = new();
        Vector2 pos = transform.position;
        Vector2 dir = DirFromAngle(startAngle);

        pts.Add(pos);

        for (int i = 0; i < maxReflections; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(pos, dir, maxDistance);

            if (!hit)
            {
                pts.Add(pos + dir * maxDistance);
                break;
            }

            pts.Add(hit.point);

            if (hit.collider.TryGetComponent(out MirrorBlock mirror))
            {
                dir = Snap(mirror.Reflect(dir));
                pos = hit.point + dir * 0.02f;
                continue;
            }

            if (hit.collider.TryGetComponent(out LaserReceiver receiver))
            {
                receiver.Activate();
                //stopLaser = true;
            }

            break;
        }

        line.positionCount = pts.Count;
        line.SetPositions(pts.ToArray());
    }

    Vector2 Snap(Vector2 d)
    {
        Vector2[] dirs =
        {
            Vector2.right, Vector2.left, Vector2.up, Vector2.down,
            new Vector2(1,1).normalized, new Vector2(1,-1).normalized,
            new Vector2(-1,1).normalized, new Vector2(-1,-1).normalized
        };

        float best = -1;
        Vector2 bestDir = dirs[0];

        foreach (var v in dirs)
        {
            float dot = Vector2.Dot(d.normalized, v);
            if (dot > best)
            {
                best = dot;
                bestDir = v;
            }
        }
        return bestDir;
    }
}
