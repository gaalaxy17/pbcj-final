using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A classe gerencia a tela de fim do jogo, com suas respectivas a��es/navega��es entre telas.
/// </summary>
public class ManageEnd : MonoBehaviour
{

    /* Start is called before the first frame update */
    void Start()
    {
    }

    /* Update is called once per frame */
    void Update()
    {
        
    }

    /* Carrega o menu do jogo */
    public void StartMenuScene()
    {
        SceneManager.LoadScene("Lab5_start");
    }

    /* Vai para a cena de cr�ditos */
    public void StartCreditsScene()
    {
        SceneManager.LoadScene("Lab5_credits");
    }
}
