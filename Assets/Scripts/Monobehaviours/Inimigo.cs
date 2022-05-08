using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que implementa as especificidades do inimigo com base na classe de Caractere
/// </summary>
public class Inimigo : Caractere
{
    float pontosVida; // equivalente à saúde do inimigo
    public int forcaDano; // poder de dano

    Coroutine danoCoroutine; // coroutine responsável pelo dano

    /* Start is called before the first frame update */
    void Start()
    {
        
    }

    /* Método que roda quando a instancia é habilitada */
    private void OnEnable()
    {
        ResetCaractere();
    }
    
    /* Método trigger para quando um objeto entra em sua área de colisão, no caso, inicia a coroutine de dano do player */
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if(danoCoroutine == null)
            {
                danoCoroutine = StartCoroutine(player.DanoCaractere(forcaDano, 1.0f));
            }
        }
    }
    
    /* Método trigger para quando um objeto sai da sua área de colisão, no caso, para a coroutine de dano do player */
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(danoCoroutine != null)
            {
                StopCoroutine(danoCoroutine);
                danoCoroutine = null;
            }
        }
    }

    /* Implementação método de dano aplicado ao inimigo, responsável por matar o inimigo caso o dano for maior que sua vida */
    public override IEnumerator DanoCaractere(int dano, float intervalo)
    {
        while (true)
        {
            StartCoroutine(FlickerCaractere());
            pontosVida = pontosVida - dano;
            if(pontosVida <= float.Epsilon)
            {
                KillCaractere();
                break;
            }
            if(intervalo > float.Epsilon)
            {
                yield return new WaitForSeconds(intervalo);
            }
            else
            {
                break;
            }
        }
    }

    /* Reinicia a vida do caractere */
    public override void ResetCaractere()
    {
        pontosVida = inicioPontosDano;
    }

    /* Update is called once per frame */
    void Update()
    {
        
    }
}
