using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Classe que implementa as especificidades do dialogo, com todas as suas respectivas funcionalidades
/// </summary>
public class ManageDialogue : MonoBehaviour
{
    public Text nameText; // Nome do personagem/NPC
    public Text dialogueText; // Texto do dialogo

    public Animator animator; // Animator do dialogo
    private Queue<string> sentences; // Queue com as frases utilizadas no dialogo

    /* Start is called before the first frame update */
    void Start()
    {
        sentences = new Queue<string>();
    }

    /* Update is called once per frame */
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("E key was pressed");
            DisplayNextSentence();
        }
    }
    /* Metodo para quando o diálogo for iniciado */
    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        Debug.Log("Staring conversation with " + dialogue.name);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    /* Metodo para mostar a proxima sequencia do diálogo*/
    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();

        StartCoroutine(TypeSentence(sentence));
    }

    /* Metodo para animar as letras ao serem apresentadas no dialogo*/
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    /* Metodo para finalizar o diálogo*/
    void EndDialogue ()
    {
        animator.SetBool("IsOpen", false);

        Debug.Log("End of the conversation.");
    }
}
