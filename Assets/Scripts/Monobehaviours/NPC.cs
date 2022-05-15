using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Classe que implementa as especificidades dos NPCs, com todas as suas respectivas funcionalidades
/// </summary>
public class NPC : MonoBehaviour
{
    public Dialogue dialogue; // Instancia do dialogo

    /* Metodo trigger para quando o player entrar no raio de colisao */
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered conversation with" + collision.gameObject.name);

        if(collision.gameObject.name == "PlayerO(Clone)")
        {
            TriggerDialogue();
        }

        
    }

    /* Metodo trigger para iniciar o dialogo ao se interagir com um NPC*/
    public void TriggerDialogue ()
    {
        Debug.Log("Dialog triggered");
        FindObjectOfType<ManageDialogue>().StartDialogue(dialogue);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
