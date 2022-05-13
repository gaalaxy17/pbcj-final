using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Classe responsável pela barra de vida, renderizada no canto superior direito do HUD
/// </summary>
public class HealthBar : MonoBehaviour
{

    public PontosDano pontosDano; // Objeto de leitura dos dados de quantos pontos tem o Player
    public Player caractere; // recebera o objeto player
    public Image medidorImagem; // recebe a barra da medição
    public Text pdTexto; // recebe os dados de PD
    float maxPontosDano; // armazena a quantidade limite de "saúde" do Player

    /* Start is called before the first frame update */
    void Start()
    {
        maxPontosDano = caractere.maxPontosDano;
    }

    /* Update is called once per frame */
    void Update()
    {
        if(caractere != null)
        {
            medidorImagem.fillAmount = pontosDano.valor / maxPontosDano;
            pdTexto.text = "HP:" + (medidorImagem.fillAmount * 100);
        }
    }
}
