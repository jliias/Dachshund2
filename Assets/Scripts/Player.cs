// Unity 3D C# script for player actions
// Author: Juha Liias
// ToDO: implement player movement

using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    // projectile prefab
    public GameObject myProjectile;

    // Projectile spawn interval
    public float intervalTime = 0.5f;

	// Use this for initialization
	void Start () {
        StartCoroutine("SpawnProjectile");
	}

    // Use repetitive coroutine for spawn projectiles with defined interval
    IEnumerator SpawnProjectile() {
        yield return new WaitForSeconds(intervalTime);
        Debug.Log("creating new projectile!");
        Vector2 myPos = this.transform.position;
        myPos.x += 2.5f;
        myPos.y += 0.3f;
        GameObject newProjectile = Instantiate(myProjectile, myPos, Quaternion.identity);
        StartCoroutine("SpawnProjectile");
    }
}
