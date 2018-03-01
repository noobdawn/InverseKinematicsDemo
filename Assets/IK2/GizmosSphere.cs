using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosSphere : MonoBehaviour {
    public Color c;
    private void OnDrawGizmos()
    {
        Gizmos.color = c;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}
