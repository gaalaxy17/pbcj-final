using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe para declarar as propriedades de um item, sendo utilizada como um scriptableObject
/// </summary>

[CreateAssetMenu(menuName = "Item")] // Faz com que o esta classe vire um tipo de objeto a ser criado, sendo que a nova classe estenderá esta
public class Item : ScriptableObject
{
    public string NomeObjeto; // Nome do objeto
    public Sprite sprite; // Sprite que será carregada no objeto
    public int quantidade; // Quantidade do objeto
    public bool empilhavel; // Boleano que salva se o item é empilhavel 
    public enum TipoItem // Enum para identificar o tipo do item
    {
        MOEDA,
        HEALTH,
        EMERALD,
        RUBY,
        DIAMOND,
        TOPAZ,
        SWORD
    }

    public TipoItem tipoItem; // Variavel do tipo do item
}
