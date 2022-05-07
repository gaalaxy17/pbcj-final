using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Caractere : MonoBehaviour
{
    public float inicioPontosDano; // Valor minimo inicial de "sa�de" do Player
    public float maxPontosDano; // Valor m�ximo permitido de "sa�de" do Player

    public abstract void ResetCaractere();

    public virtual IEnumerator FlickerCaractere()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    public abstract IEnumerator DanoCaractere(int dano, float intervalo);
    public virtual void KillCaractere()
    {
        Destroy(gameObject);
    }
}
