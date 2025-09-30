using UnityEngine;

public class AreaDebugger : MonoBehaviour
{
    [SerializeField] float pointSize;

    Sphere area = new Sphere(Vector3.zero, 3);

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(area.Center, area.Radius);

        for (int i = 0; i < 500; i++)
        {
            Gizmos.DrawSphere(area.GetRandomPointInside(), pointSize);
        }
    }
}
