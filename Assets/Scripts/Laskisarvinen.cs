// Unity3D C# script for controlling one of the enemies
// Author: Juha Liias
//
// Known issues:
// This is more or less for testing at the moment. No real
// game logic yet here. Also, comments to be added. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laskisarvinen : MonoBehaviour
{

    public GameObject hitParticle;

    private Animator anim;

    private float speed = 5f;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = this.transform.position;
        if (currentPos.x < -100f)
        {
            currentPos.x = -70f;
            currentPos.y = Random.Range(-1f, 3f);
            speed = Random.Range(5f, 10f);
        }
        else {
            currentPos.x = currentPos.x - Time.deltaTime * speed;
        }
        this.transform.position = currentPos;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("laskisarvinen_hit"))
        {
            return;
        }
        //Debug.Log("Hit On!");
        anim.SetBool("isHit", true);
        Instantiate(hitParticle, this.transform);
        StartCoroutine("BackToDefaultAnim");
    }


    IEnumerator BackToDefaultAnim()
    {
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("isHit", false);
        //Debug.Log("Hit Off!");

    }
}
