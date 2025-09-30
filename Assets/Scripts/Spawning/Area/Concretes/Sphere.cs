using UnityEngine;

public class Sphere : Area
{
    private float radius;
    private Vector3 center;

    public float Radius => radius;
    public Vector3 Center => center;

    public Sphere(Vector3 center, float radius)
    {
        this.center = center;
        this.radius = radius;
    }

    public override bool IsInside(Vector3 point)
    {
        float dist = Vector3.Distance(center, point);
        return dist < radius;
    }

    public override Vector3 GetRandomPointInside()
    {
        float x, y, z;
        Vector3 point;

        do
        {
            x = Random.Range(-radius, radius);
            y = Random.Range(-radius, radius);
            z = Random.Range(-radius, radius);

            point = new Vector3(x, y, z) + center;
        }
        while (!IsInside(point));

        return point;
    }
}
