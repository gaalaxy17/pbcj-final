using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsável pela munição da arma do personagem
/// </summary>
public class Municao : MonoBehaviour
{
    public int danoCausado; // Variavel para salvar o valor do dano causado

    /* Método trigger para quando um objeto entra em sua área de colisão, no caso, inicia a coroutine de dano do inimigo */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision is BoxCollider2D)
        {
            Inimigo inimigo = collision.gameObject.GetComponent<Inimigo>();
            StartCoroutine(inimigo.DanoCaractere(danoCausado, 0.0f));
            gameObject.SetActive(false);
        }
    }
    /* Start is called before the first frame update */
    void Start()
    {
        
    }

    /* Update is called once per frame */
    void Update()
    {
        
    }
}
