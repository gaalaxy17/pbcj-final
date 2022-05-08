using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsável pela animação e inputs da movimentação do player
/// </summary>

public class MovimentoPlayer : MonoBehaviour
{
    public float VelocidadeMovimento = 3.0f; // equivale ao momento (impulso) a ser dado ao player
    Vector2 Movimento = new Vector2(); // detectar movimento pelo teclado

    Animator animator; // guarda a componente do Controlador de Animação
    Rigidbody2D rb2D; // guarda a componente Corporigido do Player

    /* Start is called before the first frame update */
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    /* Update is called once per frame */
    void Update()
    {
        UpdateEstado();
    }

    /* Chama o método de mover o caractere */
    private void FixedUpdate()
    {
        MoveCaractere();
    }

    /* Método responsável pelo movimento, com os inputs de movimento */
    private void MoveCaractere()
    {
        Movimento.x = Input.GetAxisRaw("Horizontal");
        Movimento.y = Input.GetAxisRaw("Vertical");
        Movimento.Normalize();
        rb2D.velocity = Movimento * VelocidadeMovimento;
    }

    /* Atualiza o estado da animação, do player andando ou não */
    private void UpdateEstado()
    {
        if(Mathf.Approximately(Movimento.x, 0) && (Mathf.Approximately(Movimento.y, 0))){
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
