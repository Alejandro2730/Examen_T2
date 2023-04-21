using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PERSONAJE1 : MonoBehaviour
{
   
public GameObject bala;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    float jumFoce = 30;

    const int IDLE = 0;
    const int correr = 2;
    const int deslisar = 1;
    const int disparo = 3;
    const int saltar = 4;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up*jumFoce);
        }
        else if(Input.GetKeyUp(KeyCode.S)) {
         var currentPosition = transform.position;
         var position = new Vector3(currentPosition.x + 1, currentPosition.y, 20);
         var balaGO = Instantiate(bala, position, Quaternion.identity);
         var controller = balaGO.GetComponent<BalaController>();
         controller.velocityX = 1f;
         ChangeAnimation(disparo);
       }
       
        else if(Input.GetKeyUp(KeyCode.S)) {
         var currentPosition = transform.position;
         var position = new Vector3(currentPosition.x - 1 , currentPosition.y, -20);
         var balaGO = Instantiate(bala, position, Quaternion.identity);
         var controller = balaGO.GetComponent<BalaController>();
         controller.velocityX = -1f;
         ChangeAnimation(disparo);
       }

        else if(Input.GetKey(KeyCode.RightArrow)){
            sr.flipX = false;
            rb.velocity = new Vector2( 4, rb.velocity.y);
            ChangeAnimation(correr);
        }

        else if(Input.GetKey(KeyCode.LeftArrow)){
            sr.flipX = true;
            rb.velocity = new Vector2(-4, rb.velocity.y);
            ChangeAnimation(correr);
        }
        else if(Input.GetKey(KeyCode.Z)){
                ChangeAnimation(deslisar);
        }


        else if (Input.GetKey(KeyCode.Space)){
            ChangeAnimation(saltar);
            rb.AddForce(transform.up*jumFoce);
        }
        else{
            rb.velocity = new Vector2(0, rb.velocity.y);
            ChangeAnimation(IDLE);
        }
        
    }
    
    private void ChangeAnimation (int a){
        animator.SetInteger("Deslizar", a);
    }
}