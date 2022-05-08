using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe que implementa as especificidades do player, com todas as suas respectivas funcionalidades
/// </summary>

public class Player : Caractere
{
    public Inventario InventarioPrefab; // Referencia ao objeto prefab criado do Inventario
    Inventario inventario; // Instancia do inventario
    public HealthBar HealthBarPrefab; // Referencia ao objeto prefab criado da HealthBar
    HealthBar healthBar; // Instancia da healthbae

    public PontosDano pontosDano; // Valor da "sa�de" do objeto

    /* Start is called before the first frame update */
    private void Start()
    {
        pontosDano.valor = inicioPontosDano;
        healthBar = Instantiate(HealthBarPrefab);
        healthBar.caractere = this;
        inventario = Instantiate(InventarioPrefab);
    }

    /* Implementa o método que causa dano o player */
    public override IEnumerator DanoCaractere(int dano, float intervalo)
    {
        while (true)
        {
            StartCoroutine(FlickerCaractere());
            pontosDano.valor = pontosDano.valor - dano;
            if(pontosDano.valor <= float.Epsilon)
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
    /* Mata o player, destroi as instancias da healbar e do inventario e carrega a tela de derrota */
    public override void KillCaractere()
    {
        base.KillCaractere();
        Destroy(healthBar.gameObject);
        Destroy(inventario.gameObject);
        SceneManager.LoadScene("Lab5_defeat");
    }

    /* Reseta as instancias do inventario e healthbar, bem como sua vida */
    public override void ResetCaractere()
    {
        inventario = Instantiate(InventarioPrefab);
        healthBar = Instantiate(HealthBarPrefab);
        healthBar.caractere = this;
        pontosDano.valor = inicioPontosDano;
    }

    /* Método trigger para quando um objeto entra em sua área de colisão, no caso, para pegar um coletavel ou uma vida */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coletavel"))
        {
            Item DanoObjeto = collision.gameObject.GetComponent<Consumable>().item;
            if(DanoObjeto != null)
            {
                bool deveDesaparecer = false;
                switch (DanoObjeto.tipoItem)
                {
                    case Item.TipoItem.MOEDA:
                        deveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;
                    case Item.TipoItem.EMERALD:
                        deveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;
                    case Item.TipoItem.RUBY:
                        deveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;
                    case Item.TipoItem.DIAMOND:
                        deveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;
                    case Item.TipoItem.TOPAZ:
                        deveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;
                    case Item.TipoItem.HEALTH:
                        deveDesaparecer = AjusteDanoObjeto(DanoObjeto.quantidade);
                        break;
                    default:
                        break;
                }
                if (deveDesaparecer)
                {
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }

    /* Ajusta valor da vida */
    public bool AjusteDanoObjeto(int quantidade)
    {
        if(pontosDano.valor < maxPontosDano)
        {
            pontosDano.valor = pontosDano.valor + quantidade;
            print("Ajustando PD por: " + quantidade + ". Novo valor = " + pontosDano.valor);
            return true;
        }
        return false;
    }
}
