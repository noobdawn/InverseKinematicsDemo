using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTarget : MonoBehaviour {

    Vector3 hitPoint;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	public void UpdateHit () {
        Vector3 curPos = transform.position;
        RaycastHit info = new RaycastHit();
        if (Physics.Raycast(curPos + Vector3.up * 10, Vector3.down, out info, 20f))
        {
            if (info.collider != null)
                hitPoint = info.point;
        }
    }

    void OnDrawGizmos()
    {
        Vector3 curPos = transform.position;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(curPos + Vector3.up * 10, curPos + Vector3.down * 10);
        Gizmos.DrawSphere(hitPoint, 0.1f);
    }
    /// <summary>
    /// 蜘蛛腿放下
    /// </summary>
    public void Down()
    {
        Vector3 dist = hitPoint - transform.position;
        transform.position += dist * 0.3f;
    }
    /// <summary>
    /// 蜘蛛腿抬起
    /// </summary>
    public void Up()
    {
        transform.position += Vector3.up * 0.02f;
    }
    /// <summary>
    /// 蜘蛛腿与目标点对接
    /// </summary>
    public void Fix()
    {
        transform.position = hitPoint;
    }
}
