using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que define as propriedades do dialogo
/// </summary>

[System.Serializable]
public class Dialogue
{
    public string name; // Nome do personagem com quem o personagem esta interagindo
    [TextArea(3, 10)] // Tamanho das frases inseridas no texto
    public string[] sentences; // Frases do dialogo

}
