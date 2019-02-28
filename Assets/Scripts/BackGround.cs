// Unity3D C¤ script to manage background prefabs
// Author: Juha Liias

// These are not needed at the moment
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

    // GameObjects for background prefabs
    public GameObject backGround1;
    public GameObject backGround2;

    // Define "gamespeed" here
    // ToDo: will probably need separate class for storing common
    // settings for whole game (are used in several classes/instances)
    public float speed;

    // Variables for storing background prefab widths
    // (are used to define how they are circulated)
    private float elementWidth1;
    private float elementWidth2;

    // Use this for initialization
    void Start () {

        // 1) Get width of background1 prefab
        // 2) Save width to elementWidth1
        // 3) Define starting position for prefab
        Vector2 bg1Pos = backGround1.transform.position;
        elementWidth1 = CalcElementWidth(backGround1);
        bg1Pos.x = -elementWidth1 / 2f;
        Debug.Log("pos1: " + bg1Pos);
        backGround1.transform.position = bg1Pos;

        // Repeat same for backgound2 prefab
        Vector2 bg2Pos = backGround2.transform.position;
        elementWidth2 = CalcElementWidth(backGround2);
        bg2Pos.x = elementWidth2 / 2f;
        Debug.Log("pos2: " + bg2Pos);
        backGround2.transform.position = bg2Pos;
    }

    // Update is called once per frame
    void Update () {
        // use function to move background prefabs
        MoveBackground(backGround1, backGround2);
    }

    // Function for calculating background prefab width
    private float CalcElementWidth(GameObject bgObject) {
        Sprite bg = bgObject.GetComponentInChildren<SpriteRenderer>().sprite;
        float elementWidth = bg.rect.width / bg.pixelsPerUnit;
        Debug.Log("width: " + elementWidth);
        return elementWidth;
    }

    // function for defining position for background prefabs
    // ToDo: 1) refactoring needed here
    //       2) this does not work for prefabs of different width yet
    private void MoveBackground(GameObject bgObject1, GameObject bgObject2) {
        Vector2 bgPos1 = bgObject1.transform.position;
        Vector2 bgPos2 = bgObject2.transform.position;
        if (bgPos1.x < -2 * elementWidth2)
        {
            bgPos1.x = bgPos2.x + elementWidth2;
        }
        if (bgPos2.x < -2 * elementWidth1)
        {
            bgPos2.x = bgPos1.x + elementWidth1;
        }
        bgPos1.x -= speed * Time.deltaTime;
        bgPos2.x -= speed * Time.deltaTime;
        bgObject1.transform.position = bgPos1;
        bgObject2.transform.position = bgPos2;
    }
}
