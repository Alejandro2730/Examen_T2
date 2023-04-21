using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZOMBIE_2 : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
     
       rb.velocity = new Vector2(-1, rb.velocity.y);
         sr.flipX=true;
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "OB"){
           Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }


}
