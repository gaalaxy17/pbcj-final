using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// A classe gerencia a camera do jogo, no caso foi utilizado a camera do CineMachine
/// </summary>
public class RPGCameraManager : MonoBehaviour
{
    public static RPGCameraManager instanciaCompartilhada = null; // Instancia do manager da camera

    [HideInInspector]
    public CinemachineVirtualCamera virtualCamera; // Camera do cinemachine

    /* Método chamado quando a instancia linkada é carregada, no caso destroi o objeto da camera caso exista uma instancia compartilhada e seja diferente dessa.
     * Pega o componenete da camera do cinemachina
     */
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
        GameObject vCamGameObject = GameObject.FindWithTag("Virtual Camera");
        virtualCamera = vCamGameObject.GetComponent<CinemachineVirtualCamera>();
    }

    /* Start is called before the first frame update */
    void Start()
    {
        
    }

    /* Update is called once per frame */
    void Update()
    {
        
    }
}
