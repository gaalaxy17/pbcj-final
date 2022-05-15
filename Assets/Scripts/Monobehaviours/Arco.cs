using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que � respons�vel pela anima��o da trajetoria de arco da arma
/// </summary>
public class Arco : MonoBehaviour
{
    /* M�todo que cuida de realizar a trajet�ria da muni��o quando disparada, na forma de um arco */
    public IEnumerator arcoTrajetoria(Vector3 destino, float duracao)
    {
        var posicaoInicial = transform.position;
        var percentualCompleto = 0.0f;
        while(percentualCompleto < 1.0f)
        {
            percentualCompleto += Time.deltaTime / duracao;
            var alturaCorrente = Mathf.Sin(Mathf.PI * percentualCompleto);
            transform.position = Vector3.Lerp(posicaoInicial, destino, percentualCompleto) + Vector3.up * alturaCorrente;
            percentualCompleto += Time.deltaTime / duracao;
            yield return null;
        }
        gameObject.SetActive(false);
    }

    public IEnumerator swordTrajetoria(Vector3 destino, float duracao)
    {
        var posicaoInicial = transform.position;
        var percentualCompleto = 0.0f;
        while (percentualCompleto < 1.0f)
        {
            percentualCompleto += Time.deltaTime / duracao;
            var alturaCorrente = 0;
            transform.position = Vector3.Lerp(posicaoInicial, destino, percentualCompleto) + Vector3.up * alturaCorrente;
            percentualCompleto += Time.deltaTime / duracao;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
