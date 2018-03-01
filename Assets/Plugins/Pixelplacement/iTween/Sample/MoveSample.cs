using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{
    Vector3 hitPoint;
    void Start(){

		iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
    }
}

