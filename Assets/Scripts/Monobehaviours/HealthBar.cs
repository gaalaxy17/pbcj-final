using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public PontosDano pontosDano; // Objeto de leitura dos dados de quantos pontos tem o Player
    public Player caractere; // recebera o objeto player
    public Image medidorImagem; // recebe a barra da medição
    public Text pdTexto; // recebe os dados de PD
    float maxPontosDano; // armazena a quantidade limite de "saúde" do Player

    void Start()
    {
        maxPontosDano = caractere.maxPontosDano;
    }

    void Update()
    {
        if(caractere != null)
        {
            medidorImagem.fillAmount = pontosDano.valor / maxPontosDano;
            pdTexto.text = "PD:" + (medidorImagem.fillAmount * 100);
        }
    }
}
