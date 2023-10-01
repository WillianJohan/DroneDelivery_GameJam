using UnityEngine;

public static class TransformExtensions
{
    public static Vector3 DirectionTo(this Transform transform, Vector3 destination)
        => Vector3.Normalize(destination - transform.position);

    public static Vector3 DirectionTo(this Transform transform, Transform destination)
        => Vector3.Normalize(destination.position - transform.position);
}
