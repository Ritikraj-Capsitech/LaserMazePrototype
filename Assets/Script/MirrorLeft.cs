using UnityEngine;

public class MirrorLeft : MonoBehaviour
{
    public Vector2 Reflect(Vector2 incoming)
    {
        return new Vector2(-incoming.y, incoming.x);
    }
}

