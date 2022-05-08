using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A classe gerencia a tela de início, com suas respectivas ações/navegações entre telas.
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

    /* Carrega a cena de créditos do jogo */
    public void StartCreditsScene()
    {
        SceneManager.LoadScene("Lab5_credits");
    }
}
