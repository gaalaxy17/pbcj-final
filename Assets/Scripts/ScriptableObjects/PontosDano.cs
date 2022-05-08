using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe para declarar as propriedades dos pontos de dano utilizados no jogo, sendo utilizada como um scriptableObject
/// </summary>

[CreateAssetMenu(menuName = "PontosDano")] // Faz com que o esta classe vire um tipo de objeto a ser criado, sendo que a nova classe estenderá esta

public class PontosDano : ScriptableObject
{
    public float valor; // armazena quanto vale o objeto script
}
