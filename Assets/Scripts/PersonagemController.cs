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
//--------------------------------------------------------------------------------------
//certo aq 
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
//     private bool hasJumped; // Nova variável para controlar se já pulou


//     void Start()
//     {
//         rb2d = this.GetComponent<Rigidbody2D>();
//         groundCheckScript = groundCheck.GetComponent<GroundCheck>();
//         hasJumped = false; // Inicializa como falso
//     }

//     void Update()
//     {
//         float horizontalInput = Input.GetAxis("Horizontal");
//         if (rb2d.velocity.magnitude < 5)
//         {
//             rb2d.velocity += new Vector2(vel, 0) * horizontalInput * Time.deltaTime;
//         }

//         // Verifica se o jogador está no chão e reseta a variável
//         if (groundCheckScript.isOnGround)
//         {
//             hasJumped = false;
//         }

//         // Verifica se pode pular
//         if (Input.GetKeyDown(KeyCode.Space) && groundCheckScript.isOnGround && !hasJumped)
//         {
//             rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
//             hasJumped = true; // Marca que já pulou
//             JumpParticle(); // Chama a função de partícula
//         }
//     }

//     private void JumpParticle()
//     {
//         Instantiate(puloParticle, this.transform.position, Quaternion.Euler(-90, 0, 0));
//     }
// }
//--------------------------------------------------------------------------------------
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
    private bool hasJumped; // Variável para controlar se já pulou

    // --- NOVAS VARIÁVEIS PARA A DANÇA ---
    private Animator anim;
    private bool estaDancando = false; 

    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        groundCheckScript = groundCheck.GetComponent<GroundCheck>();
        hasJumped = false; // Inicializa como falso

        // Pega o componente Animator do personagem automaticamente
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        // Se o personagem estiver dançando, bloqueia os comandos e não executa o resto do código
        if (estaDancando)
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y); // Trava o movimento horizontal
            return;
        }

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

    // --- DETECTAR O ÚLTIMO CHÃO PELO NOME DO OBJETO ---
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o nome do objeto colidido é exatamente "Chao da Vitoria"
        if (collision.gameObject.name == "Chao (2)")
        {
            estaDancando = true; // Ativa a trava de movimento no Update

            if (anim != null)
            {
                // Dispara o Trigger chamado "fim" no seu Animator
                anim.SetTrigger("fim"); 
            }
        }
    }
}
