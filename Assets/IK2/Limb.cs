using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour {
    public GameObject targetObject;
    public LimbJoint[] Joints;
    public float[] Angles;
    public float SamplingDistance = 0.01f;
    public float LearningRate = 0.5f;
    public float DistanceThreshold = 0.05f;

    private void Awake()
    {
        Angles = new float[Joints.Length];
        GetAngles();
    }

    private void Update()
    {
        if (targetObject == null)
            return;
        GetAngles();
        InverseKinematics(targetObject.transform.position, Angles);
        SetAngles();
    }

    private void GetAngles()
    {
        for (int i = 0; i < Joints.Length; i++)
        {
            Angles[i] = Joints[i].Angle;
        }
    }

    private void SetAngles()
    {
        for (int i = 0; i < Joints.Length; i++)
        {
            Joints[i].Angle = Angles[i];
        }
    }

    public Vector3 ForwardKinematics(float[] angles)
    {
        //如果输入对不上号，那就直接返回
        if (angles.Length != Joints.Length)
            return Joints[0].transform.position;
        //从第一个关节开始
        Vector3 prevPoint = Joints[0].transform.position;
        //初始化角度
        Quaternion rotation = Quaternion.identity;
        for (int i = 1; i < Joints.Length; i++)
        {
            //绕某直线旋转，并合并四元数
            rotation *= Quaternion.AngleAxis(angles[i - 1], Joints[i - 1].Axis);
            //更新位置
            Vector3 nextPoint = prevPoint + rotation * Joints[i].StartOffset;
            prevPoint = nextPoint;
        }
        return prevPoint;
    }

    public float DistanceFromTarget(Vector3 target, float[] angles)
    {
        if (target == Joints[0].transform.position) return 0f;
        Vector3 point = ForwardKinematics(angles);
        return Vector3.Distance(point, target);
    }

    public float PartialGradient(Vector3 target, float[] angles, int i)
    {
        //保存角度，随后重新存回来
        float angle = angles[i];

        //梯度 : [F(x+SamplingDistance) - F(x)] / h
        //两次采样
        float f_x = DistanceFromTarget(target, angles);
        angles[i] += SamplingDistance;
        float f_x_plus_d = DistanceFromTarget(target, angles);
        float gradient = (f_x_plus_d - f_x) / SamplingDistance;
        //恢复现场
        angles[i] = angle;
        return gradient;
    }

    public void InverseKinematics(Vector3 target, float[] angles)
    {
        if (DistanceFromTarget(target, angles) < DistanceThreshold)
            return;

        for (int i = Joints.Length - 1; i >= 0; i--)
        {
            // 梯度下降法
            // Update : Solution -= LearningRate * Gradient
            float gradient = PartialGradient(target, angles, i);
            angles[i] -= LearningRate * Mathf.Sign(gradient);
            angles[i] = Mathf.Clamp(angles[i], Joints[i].MinAngle, Joints[i].MaxAngle);
            // 提前退出
            if (DistanceFromTarget(target, angles) < DistanceThreshold)
                return;
        }
    }
}
