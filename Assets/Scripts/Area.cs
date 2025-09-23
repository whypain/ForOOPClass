using UnityEngine;

public abstract class Area
{
    public abstract bool IsInside(Vector3 point);
    public abstract Vector3 GetRandomPointInside();
}
