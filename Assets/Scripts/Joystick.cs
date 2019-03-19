// Unity3D C# script to implement kind of a virtual joystick
//
// Origin of this script:
// https://pressstart.vip/tutorials/2018/06/22/39/mobile-joystick-in-unity.html
// Some small changes are done, and final version will probably be created 
// based on the experiences on this and other implementations.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 10.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    // circles to build a joystick object
    public Transform circle;
    public Transform outerCircle;

    public Camera myCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            circle.transform.position = pointA * -1;
            outerCircle.transform.position = pointA * 1;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }

    }

    // FixedUpdate is called fixed frame-rate frame
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction * 1.5f);

            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * 1;
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    // moveCharacter() is modified heavily to meet requirements for 
    // player movement. 
    void moveCharacter(Vector2 direction)
    {
        // Check player's relative position within camera viewport
        Vector2 screenPoint = myCamera.WorldToViewportPoint(player.position);
        // Player can't be moved outside viewport. 
        // Position must be within rectangle (0,0)-(1,1)
        if ((screenPoint.x < 0 && direction.x < 0) || (screenPoint.x > 1 && direction.x > 0))
        {
            direction.x = 0f;
        }
        if ((screenPoint.y < 0 && direction.y < 0) || (screenPoint.y > 1 && direction.y > 0))
        {
            direction.y = 0f;
        }
        // Move player to desired direction with defined speed
        player.Translate(direction * speed * Time.deltaTime);
    }
}