using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe base para os caracteres presentes no jogo
/// </summary>
public abstract class Caractere : MonoBehaviour
{
    public float inicioPontosDano; // Valor minimo inicial de "sa�de" do Player
    public float maxPontosDano; // Valor m�ximo permitido de "sa�de" do Player

    /* Defini��o do m�todo abstrato de resetar o caractere */
    public abstract void ResetCaractere();

    /* M�todo respons�vel pela anima��o de dano que o personagem sofre, piscando em vermelho */
    public virtual IEnumerator FlickerCaractere()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    /* Defini��o do m�todo abstrato respons�vel pelo dano */
    public abstract IEnumerator DanoCaractere(int dano, float intervalo);

    /* M�todo respons�vel por matar o personagem, ou seja, destruir sua inst�ncia */
    public virtual void KillCaractere()
    {
        Destroy(gameObject);
    }
}
