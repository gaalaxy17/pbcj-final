using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name; // Nome do personagem com que esta interagindo
    [TextArea(3, 10)]
    public string[] sentences; // Frases do dialogo

}
