using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento2D : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;
    AudioSource audio;
    Collider2D groundCheck;
    bool isGrounded;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        groundCheck = GetComponent<CircleCollider2D>();
    }

    void Update () {
        HandleAnimations();
    }

    void OnCollisionEnter2D (Collision2D other) {
        if(other.gameObject.CompareTag("Platform")){
            this.transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Platform")){
            this.transform.parent = null;
        }
    }

    void FixedUpdate()
    {   
        float axisX = 0f;
        float axisY = 0f;

        isGrounded = Physics2D.IsTouchingLayers(groundCheck);

        if (rb && (axisX = Input.GetAxis("Horizontal")) != 0){
            
            rb.AddForce(new Vector2(5 * axisX, 0));
            
            spriteRenderer.flipX = axisX < 0 ? true : spriteRenderer.flipX;
            spriteRenderer.flipX = axisX > 0 ? false : spriteRenderer.flipX;
        }

        if (rb && (axisY = Input.GetAxis("Jump")) > 0) {
            if (Mathf.Abs(rb.velocity.y) < 0.01f && isGrounded == true){
                rb.AddForce(new Vector2(0, 5 * axisY), ForceMode2D.Impulse);
                audio.Play();
            }
        }
    }

    void HandleAnimations (){
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetBool("IsGrounded", isGrounded);
    }
}
