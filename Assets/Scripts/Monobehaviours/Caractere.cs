using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe base para os caracteres presentes no jogo
/// </summary>
public abstract class Caractere : MonoBehaviour
{
    public float inicioPontosDano; // Valor minimo inicial de "saúde" do Player
    public float maxPontosDano; // Valor máximo permitido de "saúde" do Player

    /* Definição do método abstrato de resetar o caractere */
    public abstract void ResetCaractere();

    /* Método responsável pela animação de dano que o personagem sofre, piscando em vermelho */
    public virtual IEnumerator FlickerCaractere()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    /* Definição do método abstrato responsável pelo dano */
    public abstract IEnumerator DanoCaractere(int dano, float intervalo);

    /* Método responsável por matar o personagem, ou seja, destruir sua instância */
    public virtual void KillCaractere()
    {
        Destroy(gameObject);
    }
}
