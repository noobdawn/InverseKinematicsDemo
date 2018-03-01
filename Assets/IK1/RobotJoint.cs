using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotJoint : MonoBehaviour {
    //角度
    public float angle;
    public float Angle
    {
        get { return angle; }
        set { angle = value; transform.localEulerAngles = Axis * value; }
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
