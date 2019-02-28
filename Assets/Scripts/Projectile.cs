// Unity3D C# script for projectile actions
// Author: Juha Liias
// Moves projectile to right with defined speed.
// Will destroy self after lifeTime

using System.Collections;
// not needed at the moment
// using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    // Variables for speed and lifetime
    public float speed;
    public float lifeTime;

	// Use this for initialization
	void Start () {
        StartCoroutine("DestroySelf");
	}
	
	// Update is called once per frame
	void Update () {
        // Move projectile to right on each frame
        // ToDo: check if there are better ways to implement movement
        Vector2 thisPos = this.transform.position;
        thisPos.x += speed * Time.deltaTime;
        this.transform.position = thisPos;
	}

    // Coroutine that destroys projectile after lifeTime
    // ToDo: Can same functionality be implemented simply with delayed Destroy()?
    IEnumerator DestroySelf() {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
        yield return null;
    }
}
