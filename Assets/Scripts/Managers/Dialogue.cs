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
    [TextArea(2, 3)] // Tamanho dos campos para inserir os diálogos
    public string[] sentences; // Frases do dialogo

}
