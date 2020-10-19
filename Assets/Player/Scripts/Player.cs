using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
public class Player : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool facingRight = true;
    public float speed;     
    private float moveLimiter = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // Pega posição Horizontal e Vertical
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Seta o valor das variaveis no anim controller
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        // Verifica se está se movendo na diagonal
        if (movement.x != 0 && movement.y != 0) 
        {
            // Limita a velocidade do movimento diagonalmente, para que você se mova a 80% da velocidade
            movement.x *= moveLimiter;
            movement.y *= moveLimiter;
        } 

        // Movimenta o player
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);

        // Vira o personagem para a direção que ele esta indo
        if(movement.x > 0 && !facingRight)
        {
            Flip();
        }
        else if(movement.x < 0 && facingRight)
        {
            Flip();
        } 
    }

    void footstep(){
        GetComponent<AudioSource>().volume = Random.Range(0.5f, 1.0f);
        GetComponent<AudioSource>().Play();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 newPlayerScale = transform.localScale;
        newPlayerScale.x *= -1;
        transform.localScale = newPlayerScale; 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("Collider", true);
    }

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        animator.SetBool("Collider", false);
    }
}
