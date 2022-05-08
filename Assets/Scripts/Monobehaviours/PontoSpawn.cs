using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsável pelo ponto de spawn do player
/// </summary>

public class PontoSpawn : MonoBehaviour
{
    public GameObject prefabParaSpawn; // prefab do ponto de spawn
    public float intervaloRepeticao; // intervalo de spawn do objeto

    /* Start is called before the first frame update */
    void Start()
    {
        if(intervaloRepeticao > 0)
        {
            InvokeRepeating("SpawnO", 0.0f, intervaloRepeticao);
        }
    }
    /* Spawna o objeto setado como prefab no lugar desejado */
    public GameObject SpawnO()
    {
        if(prefabParaSpawn != null)
        {
            return Instantiate(prefabParaSpawn, transform.position, Quaternion.identity);
        }
        return null;
    }

    /* Update is called once per frame */
    void Update()
    {
        
    }
}
