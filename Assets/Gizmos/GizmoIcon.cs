using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoIcon : MonoBehaviour
{
    public enum GizmoIconType
    {
        Cube,
        WireCube,
        Sphere,
        WireSphere
    }
    public Color gizmoColor;
    public GizmoIconType gizmoType;
    public float gizmoRadius;

    private void Start()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        switch(gizmoType)
        {
            case GizmoIconType.Cube:
                Gizmos.DrawCube(transform.position, new Vector3(
                    transform.localScale.x * gizmoRadius,
                    transform.localScale.y * gizmoRadius,
                    transform.localScale.z * gizmoRadius));
                break;
            case GizmoIconType.WireCube:
                Gizmos.DrawWireCube(transform.position, new Vector3(
                   transform.localScale.x * gizmoRadius,
                   transform.localScale.y * gizmoRadius,
                   transform.localScale.z * gizmoRadius));
                break;
            case GizmoIconType.Sphere:
                Gizmos.DrawSphere(transform.position, gizmoRadius);
                break;
            case GizmoIconType.WireSphere:
                Gizmos.DrawWireSphere(transform.position, gizmoRadius);
                break;
        }
    }
}
