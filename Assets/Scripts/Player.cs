﻿// Unity 3D C# script for player actions
// Author: Juha Liias
// ToDO: implement player movement

using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    // projectile prefab
    public GameObject myProjectile;

    private Camera myCamera;

    // Projectile spawn interval
    public float intervalTime = 0.1f;

    public float speed = 10f;

    // 
    private Vector3 currentPos;
    private Vector3 targetPos;

	// Use this for initialization
	void Start () {
        myCamera = FindObjectOfType<Camera>();
        targetPos = this.transform.position;
        StartCoroutine("SpawnProjectile");
	}

    private void Update()
    {
        currentPos = this.transform.position;
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -10f;
            targetPos = myCamera.ScreenToWorldPoint(mousePos);
            targetPos.z = currentPos.z; 
            Debug.Log("currentPos: " + currentPos);
            Debug.Log("target: " + targetPos);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

    }

    // Use repetitive coroutine for spawn projectiles with defined interval
    IEnumerator SpawnProjectile() {
        yield return new WaitForSeconds(intervalTime);
        //Debug.Log("creating new projectile!");
        Vector2 myPos = this.transform.position;
        myPos.x += 2.5f;
        myPos.y += 0.3f;
        GameObject newProjectile = Instantiate(myProjectile, myPos, Quaternion.identity);
        StartCoroutine("SpawnProjectile");
    }
}
