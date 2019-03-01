// Unity C# script for camera movement
// Author: Juha Liias

// Next two lines not needed at the moment:
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    // GameObject for camera target
    public GameObject target;

    // ToDo: remove start(), if no use
	// Use this for initialization
	void Start () {
        // Follow target. This might also be redundant since player
        // is not moving in this project (at the moment).
        Vector3 targetPos = target.transform.position;
        targetPos.x += 4f;
        targetPos.y = 0f;
        targetPos.z = -10f;
        this.transform.position = targetPos;
    }
	
	// Update is called once per frame
	void Update () {

	}
}
