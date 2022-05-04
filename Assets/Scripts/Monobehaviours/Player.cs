using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Caractere
{
    public Inventario inventarioPrefab; // Referencia ao objeto prefab criado do Inventario
    Inventario inventario;
    public HealthBar HealthBarPrefab; // Referencia ao objeto prefab criado da HealthBar
    HealthBar healthBar;

    private void Start()
    {
        pontosDano.valor = inicioPontosDano;
        healthBar = Instantiate(HealthBarPrefab);
        healthBar.caractere = this;
        inventario = Instantiate(inventarioPrefab);
    }

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
