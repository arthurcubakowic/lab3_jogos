/// <summary>
/// Projeto Final Programaao Baseada em Componentes para Jogos
/// Prof Dr. Mario Minami
/// Feito Por: Arthur Cubakowic, RA: 11201722317
/// Data: 25/04/2021
/// Versao do Unity: 2020.3.0f1
/// </summary>


using UnityEngine;

public class MovimentaPlayer : MonoBehaviour
{
    public float VelocidadeDeMovimento = 3.0f;                  // Move Speed
    Vector2 Movimento = new Vector2();                          // Vetor de movimento

    Animator animator;                                          // Animacao que ira rodar

    Rigidbody2D rb2D;                


    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        UpDateEstado();
    }

    private void FixedUpdate()
    {
        MoveCaractere();
    }

    // Move o personagem
    private void MoveCaractere()
    {
        Movimento.x = Input.GetAxisRaw("Horizontal");
        Movimento.y = Input.GetAxisRaw("Vertical");
        Movimento.Normalize();
        rb2D.velocity = Movimento * VelocidadeDeMovimento;
    }

    // Troca as sprites ao movimentar o personagem
    void UpDateEstado()
    {
        if (Mathf.Approximately(Movimento.x, 0) && (Mathf.Approximately(Movimento.y, 0)))
        {
            animator.SetBool("Caminhando", false);
        }
        else
        {
            animator.SetBool("Caminhando", true);
        }
        animator.SetFloat("dirX", Movimento.x);
        animator.SetFloat("dirY", Movimento.y);
    }
}

