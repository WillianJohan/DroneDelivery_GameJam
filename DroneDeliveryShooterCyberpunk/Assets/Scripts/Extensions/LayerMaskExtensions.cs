using UnityEngine;

public static class LayerMaskExtensions
{
    public static bool Contains(this LayerMask myLayer, int other)
        => (myLayer & 1 << other) == (1 << other);
}
