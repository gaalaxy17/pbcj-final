using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageCredits : MonoBehaviour
{

    // Start is called before the first frame update */
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

    /* Sai do jogo */
    public void QuitGame()
    {
        Application.Quit();
    }
}
