using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Caractere : MonoBehaviour
{
    public float inicioPontosDano; // Valor minimo inicial de "saúde" do Player
    public float maxPontosDano; // Valor máximo permitido de "saúde" do Player

    public abstract void ResetCaractere();
    public abstract IEnumerator DanoCaractere(int dano, float intervalo);
    public virtual void KillCaractere()
    {
        Destroy(gameObject);
    }
}
