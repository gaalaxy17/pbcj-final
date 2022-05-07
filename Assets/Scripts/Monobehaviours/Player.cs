using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Caractere
{
    public Inventario InventarioPrefab; // Referencia ao objeto prefab criado do Inventario
    Inventario inventario;
    public HealthBar HealthBarPrefab; // Referencia ao objeto prefab criado da HealthBar
    HealthBar healthBar;

    public PontosDano pontosDano; // Valor da "saúde" do objeto

    private void Start()
    {
        pontosDano.valor = inicioPontosDano;
        healthBar = Instantiate(HealthBarPrefab);
        healthBar.caractere = this;
        inventario = Instantiate(InventarioPrefab);
    }

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

    public override void KillCaractere()
    {
        base.KillCaractere();
        Destroy(healthBar.gameObject);
        Destroy(inventario.gameObject);
    }

    public override void ResetCaractere()
    {
        inventario = Instantiate(InventarioPrefab);
        healthBar = Instantiate(HealthBarPrefab);
        healthBar.caractere = this;
        pontosDano.valor = inicioPontosDano;
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
