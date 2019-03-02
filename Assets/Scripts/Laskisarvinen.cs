using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laskisarvinen : MonoBehaviour
{

    private Animator anim;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("laskisarvinen_hit"))
        {
            return;
        }
        Debug.Log("Hit On!");
        anim.SetBool("isHit", true);
        StartCoroutine("BackToDefaultAnim");
    }


    IEnumerator BackToDefaultAnim()
    {
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("isHit", false);
        Debug.Log("Hit Off!");

    }
}
