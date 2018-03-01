using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {
    public float Speed;
    //一次移动所需要的帧数
    public int MoveFrames;
    private int CurFrames;
    private bool IsLeftFeet;

    public GameObject[] Feets;

    void Start()
    {
        CurFrames = 0;
        IsLeftFeet = true;
    }

    private void FixedUpdate()
    {
        CurFrames++;
        //如果移动周期到了，就换一组足
        if (CurFrames >= MoveFrames)
        {
            CurFrames = 0;
            IsLeftFeet = !IsLeftFeet;
        }
        //暂存该锁定的足位置
        int idx = IsLeftFeet ? 1 : 0;
        Vector3 curPosition = Feets[idx].transform.position;
        //移动本体
        transform.position += Speed * Vector3.forward;
        //锁定该锁定的足的位置
        Feets[idx].transform.position = curPosition;
        StepTarget[] steps = Feets[idx].GetComponentsInChildren<StepTarget>();
        foreach(var s in steps)
        {
            s.UpdateHit();
            s.Fix();
        }
        //移动该移动的足
        idx = IsLeftFeet ? 0 : 1;
        Feets[idx].transform.position += Speed * Vector3.forward;
        steps = Feets[idx].GetComponentsInChildren<StepTarget>();
        foreach (var s in steps)
        {
            s.UpdateHit();
            if (CurFrames > MoveFrames * 0.5f)
                s.Down();
            else
                s.Up();
        }
    }
}
