using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager principal do RPG, responsável pelo spawn do player e pelo setup inicial da camera
/// </summary>
public class RPGGameManager : MonoBehaviour
{
    public static RPGGameManager instanciaCompartilhada = null; // Instancia do gameManager
    public RPGCameraManager cameraManager; // Instacia do cameraManager

    public PontoSpawn playerPontoSpawn; // Referencia ao ponto de spawn para o jogador

    /* Método roda ao carregar o a sua instancia e faz a sua atribuição */
    private void Awake()
    {
        if(instanciaCompartilhada != null && instanciaCompartilhada != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instanciaCompartilhada = this;
        }
    }

    /* Faz o setup da cena inicial */
    public void SetupScene()
    {
        SpawnPlayer();
    }

    /* Método responsável pelo spawn do player e pela configuração inicial da camera, para seguir o jogador */
    public void SpawnPlayer()
    {
        if(playerPontoSpawn != null)
        {
            GameObject player = playerPontoSpawn.SpawnO();
            cameraManager.virtualCamera.Follow = player.transform;
        }
    }

    /* Start is called before the first frame */
    void Start()
    {
        SetupScene();
    }

    /* Update is called once per frame */
    void Update()
    {
        
    }
}
