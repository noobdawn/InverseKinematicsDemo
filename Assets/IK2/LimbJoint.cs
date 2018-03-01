using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbJoint : MonoBehaviour {
    public float angle;
    public float Angle
    {
        get { return angle; }
        set {
            angle = value;
            Vector3 temp = transform.localEulerAngles;
            temp.x = Axis.x == 0 ? temp.x : value;
            temp.y = Axis.y == 0 ? temp.y : value;
            temp.z = Axis.z == 0 ? temp.z : value;
            transform.localEulerAngles = temp;
        }
    }
    public float MaxAngle;
    public float MinAngle;
    //轴
    public Vector3 Axis;
    //这个关节与上一个关节之间的偏移（或者说肢体长）
    public Vector3 StartOffset;
    private void Awake()
    {
        StartOffset = transform.localPosition;
        angle = 0f;
    }
}
