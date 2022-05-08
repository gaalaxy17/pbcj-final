using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsável pela ação de perambular do inimigo
/// </summary>

[RequireComponent(typeof(Rigidbody2D))] // Requer que o componente esteja presente na instancia, caso não esteja, adiciona o mesmo
[RequireComponent(typeof(CircleCollider2D))] // Requer que o componente esteja presente na instancia, caso não esteja, adiciona o mesmo
[RequireComponent(typeof(Animator))] // Requer que o componente esteja presente na instancia, caso não esteja, adiciona o mesmo

public class Perambular : MonoBehaviour
{
    public float velocidadePerseguicao; // velocidade do "Inimigo" na área de Spot
    public float velocidadePerambular; // velocidade do "Inimigo" passeando
    float velocidadeCorrente; // velocidade atual

    public float intervaloMudancaDirecao; // tempo para alterar direção
    public bool perseguePlayer; // indicador de perseguidor ou não

    Coroutine MoverCoroutine; // Coroutine de movimento

    Rigidbody2D rb2D; // armazena o componente rigidbody2D
    Animator animator; // armazena o componente Animator

    Transform alvoTransform = null; // armazena o componente Transform do Alvo

    Vector3 posicaoFinal; // Vetor da posição final
    float anguloAtual = 0; // Angulo atribuido

    CircleCollider2D circleCollider; // armazena o componente de Spot

    /* Start is called before the first frame update */
    void Start()
    {
        animator = GetComponent<Animator>();
        velocidadeCorrente = velocidadePerambular;
        rb2D = GetComponent<Rigidbody2D>();
        StartCoroutine(RotinaPerambular());
        circleCollider = GetComponent<CircleCollider2D>();
    }

    /* Função para debug do collider */
    private void OnDrawGizmos()
    {
        if(circleCollider != null)
        {
            Gizmos.DrawWireSphere(transform.position, circleCollider.radius);
        }
    }

    /* Corotine de perambular */
    public IEnumerator RotinaPerambular()
    {
        while (true)
        {
            EscolheNovoPontoFinal();
            if(MoverCoroutine != null)
            {
                StopCoroutine(MoverCoroutine);
            }
            MoverCoroutine = StartCoroutine(Mover(rb2D, velocidadeCorrente));
            yield return new WaitForSeconds(intervaloMudancaDirecao);
        }
    }

    /* Escolhe a nova posição de forma aleatória */
    void EscolheNovoPontoFinal()
    {
        anguloAtual += Random.Range(0, 360);
        anguloAtual = Mathf.Repeat(anguloAtual, 360);
        posicaoFinal += Vector3ParaAngulo(anguloAtual);
    }

    /* Retorna o vetor para o angulo da ação */
    Vector3 Vector3ParaAngulo(float anguloEntradaGraus)
    {
        float anguloEntradaRadianos = anguloEntradaGraus * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(anguloEntradaRadianos), Mathf.Sin(anguloEntradaRadianos), 0);
    }

    /* Método que move o inimigo para um ponto durante a ação de perambular */
    public IEnumerator Mover(Rigidbody2D rbParaMover, float velocidade)
    {
        float distanciaFaltante = (transform.position - posicaoFinal).sqrMagnitude;
        while(distanciaFaltante > float.Epsilon)
        {
            if(alvoTransform != null)
            {
                posicaoFinal = alvoTransform.position;
            }
            if(rbParaMover != null)
            {
                animator.SetBool("Caminhando", true);
                Vector3 novaPosicao = Vector3.MoveTowards(rbParaMover.position, posicaoFinal, velocidade * Time.deltaTime);
                rb2D.MovePosition(novaPosicao);
                distanciaFaltante = (transform.position - posicaoFinal).sqrMagnitude;
            }
            yield return new WaitForFixedUpdate();
        }
        animator.SetBool("Caminhando", false);
    }
    /* Método trigger para quando um objeto entra em sua área de colisão, no caso, inicia a coroutine de mover, no spot, na velocidade de perseguição */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && perseguePlayer)
        {
            velocidadeCorrente = velocidadePerseguicao;
            alvoTransform = collision.gameObject.transform;
            if(MoverCoroutine != null)
            {
                StopCoroutine(MoverCoroutine);
            }
            MoverCoroutine = StartCoroutine(Mover(rb2D, velocidadeCorrente));
        }
    }
    /* Método trigger para quando um objeto sai em sua área de colisão, no caso, do spot e volta para a velocidade de perambular */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Caminhando", false);
            velocidadeCorrente = velocidadePerambular;
            if(MoverCoroutine != null)
            {
                StopCoroutine(MoverCoroutine);
            }
            alvoTransform = null;
        }
    }

    /* Update is called once per frame */
    void Update()
    {
        Debug.DrawLine(rb2D.position, posicaoFinal, Color.red);
    }
}
