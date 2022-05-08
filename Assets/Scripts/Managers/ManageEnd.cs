using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageEnd : MonoBehaviour
{

    // Start is called before the first frame update */
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

    public void StartCreditsScene()
    {
        SceneManager.LoadScene("Lab5_credits");
    }
}
