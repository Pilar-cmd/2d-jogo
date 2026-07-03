// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PersonagemController : MonoBehaviour
// {
//     public Rigidbody2D rb2d;
//     public float vel;
//     public float jumpForce;
//     public GameObject groundCheck;
//     private GroundCheck groundCheckScript;
    
//     public GameObject puloParticle;


//     void Start()
//     {
//         rb2d = this.GetComponent<Rigidbody2D>();
//         groundCheckScript = groundCheck.GetComponent<GroundCheck>();

//     }

//     void Update()
//     {
//         float horizontalInput = Input.GetAxis("Horizontal");
//         if (rb2d.velocity.magnitude < 5)
//         {
//             rb2d.velocity += new Vector2(vel, 0) * horizontalInput * Time.deltaTime;
//         }

//         if (Input.GetKey(KeyCode.Space) && groundCheckScript.isOnGround)
//         {
//             rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
//         }
//     }

//     private void JumpParticle()
//     {
//         Instantiate(puloParticle, this.transform.position, Quaternion.Euler(-90, 0, 0));
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float vel;
    public float jumpForce;
    public GameObject groundCheck;
    private GroundCheck groundCheckScript;
    
    public GameObject puloParticle;
    private bool hasJumped; // Nova variável para controlar se já pulou


    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        groundCheckScript = groundCheck.GetComponent<GroundCheck>();
        hasJumped = false; // Inicializa como falso
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (rb2d.velocity.magnitude < 5)
        {
            rb2d.velocity += new Vector2(vel, 0) * horizontalInput * Time.deltaTime;
        }

        // Verifica se o jogador está no chão e reseta a variável
        if (groundCheckScript.isOnGround)
        {
            hasJumped = false;
        }

        // Verifica se pode pular
        if (Input.GetKeyDown(KeyCode.Space) && groundCheckScript.isOnGround && !hasJumped)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            hasJumped = true; // Marca que já pulou
            JumpParticle(); // Chama a função de partícula
        }
    }

    private void JumpParticle()
    {
        Instantiate(puloParticle, this.transform.position, Quaternion.Euler(-90, 0, 0));
    }
}