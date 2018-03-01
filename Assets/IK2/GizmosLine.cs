using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosLine : MonoBehaviour {
    public GameObject[] gos;
    private void OnDrawGizmos()
    {
        for (int i = 0; i < gos.Length - 1; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(gos[i].transform.position, gos[i + 1].transform.position);
        }
    }
}
