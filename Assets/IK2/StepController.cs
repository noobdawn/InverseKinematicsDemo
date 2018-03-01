using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour {
    public GameObject LeftStep;
    public GameObject RightStep;
    //路径寻路中的所有点
    public Transform[] LeftPaths;
    public Transform[] RightPaths;

    void Start()
    {
        Hashtable args = new Hashtable();
        //设置路径的点
        args.Add("path", LeftPaths);
        //设置类型为线性，线性效果会好一些。
        args.Add("easeType", iTween.EaseType.linear);
        //设置寻路的速度
        args.Add("speed", 5f);
        //是否先从原始位置走到路径中第一个点的位置
        args.Add("movetopath", true);
        //是否让模型始终面朝当面目标的方向，拐弯的地方会自动旋转模型
        //如果你发现你的模型在寻路的时候始终都是一个方向那么一定要打开这个
        args.Add("orienttopath", true);
        //让模型开始寻路	
        iTween.MoveTo(LeftStep, args);

        args = new Hashtable();
        //设置路径的点
        args.Add("path", RightPaths);
        //设置类型为线性，线性效果会好一些。
        args.Add("easeType", iTween.EaseType.linear);
        //设置寻路的速度
        args.Add("speed", 5f);
        //是否先从原始位置走到路径中第一个点的位置
        args.Add("movetopath", true);
        //是否让模型始终面朝当面目标的方向，拐弯的地方会自动旋转模型
        //如果你发现你的模型在寻路的时候始终都是一个方向那么一定要打开这个
        args.Add("orienttopath", true);
        //让模型开始寻路	
        iTween.MoveTo(RightStep, args);
    }

    void OnDrawGizmos()
    {
        //在scene视图中绘制出路径与线
        iTween.DrawLine(LeftPaths, Color.yellow);
        iTween.DrawPath(RightPaths, Color.red);
    }
}
