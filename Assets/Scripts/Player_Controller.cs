using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 700f;

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D rBody;
    private Animator anim;
    private AudioSource audiosource;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();

        jumpCount = 0;
        isGrounded = false;
        isDead = false;
    }

    void Update()
    {
        if (isDead) return;

        
        if (Input.GetButtonDown(GameManager.JMP) && jumpCount < 2)
        {
            jumpCount++;
            rBody.velocity = Vector2.zero;
            rBody.AddForce(Vector2.up * jumpForce);
            audiosource.Play();
        }
        else if(Input.GetButtonUp(GameManager.JMP) && rBody.velocity.y > 0f)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, rBody.velocity.y * 0.5f);
        }

        anim.SetBool("Grounded", isGrounded);
    }

    public void Die()
    {
        isDead = true;
        audiosource.clip = deathClip;
        audiosource.Play();
        anim.SetTrigger("Die");

        rBody.velocity = Vector3.zero;
        rBody.gravityScale = 0f;

        GameManager.Instance().OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;
        if (collision.gameObject.CompareTag("Hazard"))
            Die();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y < 0.7f) return;
        isGrounded = true;
        jumpCount = 0;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
