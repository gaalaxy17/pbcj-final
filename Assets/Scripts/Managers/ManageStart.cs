using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A classe gerencia a tela de in�cio, com suas respectivas a��es/navega��es entre telas.
/// </summary>
public class ManageStart : MonoBehaviour
{

    /* Start is called before the first frame update */
    void Start()
    {
    }

    /* Update is called once per frame */
    void Update()
    {
        
    }

    /* Carrega a cena principal do jogo */
    public void StartGameWorld()
    {
        SceneManager.LoadScene("Lab5_RPGSetup");
    }

    /* Carrega a cena de cr�ditos do jogo */
    public void StartCreditsScene()
    {
        SceneManager.LoadScene("Lab5_credits");
    }
}
