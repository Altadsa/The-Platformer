using UnityEngine;

public enum Layer
{
    Background = 8,
    Hazards = 9,
    Climables = 10,
    Collectables = 11,
    Enemies = 12,
    Player = 13,
    Foreground = 14,
    Platforms = 15
}

public static class Layers
{
    public static bool IsColliderTouchingLayers(Collider2D activeCollider, Layer[] layers)
    {
        foreach (Layer layer in layers)
        {
            int layerMask = 1 << (int)layer;
            if (activeCollider.IsTouchingLayers(layerMask))
            {
                return true;
            }
        }
        return false;
    }
}
