using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindBone : MonoBehaviour {
    public GameObject bone;
	// Update is called once per frame
	void Update () {
        transform.position = bone.transform.position;
	}
}
