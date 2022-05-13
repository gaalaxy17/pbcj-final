using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsável pelas mecânicas das armas do jogo
/// </summary>

[RequireComponent(typeof(Animator))]
public class Armas : MonoBehaviour
{

    public GameObject municaoPrefab; // armazena o prefab da munição
    static List<GameObject> municaoPiscina; // piscina da munição
    public int tamanhoPiscina; // Tamanho da piscina
    public float velocidadeArma; // velocidade da Munição

    bool atirando; // Campo que salva o estado da ação de atirar
    [HideInInspector]
    public Animator animator; // Instancia do animator

    Camera cameraLocal; // Instancia da camera

    float slopePositivo; // Variavel que salva o slopePositivo
    float slopeNegativo; // Variavel que salva o slopeNegativo

    enum Quadrante // Enum com os quadrantes existentes
    {
        Leste,
        Sul,
        Oeste,
        Norte
    }

    /* Método roda no carregamento da instância, cria ou adiciona munições na pool de objetos */
    public void Awake()
    {
        if(municaoPiscina == null)
        {
            municaoPiscina = new List<GameObject>();
        }
        for(int i = 0; i < tamanhoPiscina; i++)
        {
            GameObject municaoO = Instantiate(municaoPrefab);
            municaoO.SetActive(false);
            municaoPiscina.Add(municaoO);
        }
    }


    /* Start is called before the first frame update */
    private void Start()
    {
        animator = GetComponent<Animator>();
        atirando = false;
        cameraLocal = Camera.main;
        Vector2 abaixoEsquerda = cameraLocal.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 acimaDireita = cameraLocal.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 acimaEsquerda = cameraLocal.ScreenToWorldPoint(new Vector2(0, Screen.height));
        Vector2 abaixoDireita = cameraLocal.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        slopePositivo = PegaSlope(abaixoEsquerda, acimaDireita);
        slopeNegativo = PegaSlope(acimaEsquerda, abaixoDireita);
    }

    /* Método que retorna true caso esteja acima do slope positivo e false no caso contrário */
    bool AcimaSlopePositivo(Vector2 posicaoEntrada)
    {
        Vector2 posicaoPlayer = gameObject.transform.position;
        Vector2 posicaoMouse = cameraLocal.ScreenToWorldPoint(posicaoEntrada);
        float interseccaoY = posicaoPlayer.y - (slopePositivo * posicaoPlayer.x);
        float entradaInterseccao = posicaoMouse.y - (slopePositivo * posicaoMouse.x);
        return entradaInterseccao > interseccaoY;
    }
    /* Método que retorna true caso esteja acima do slope negativo e false no caso contrário */
    bool AcimaSlopeNegativo(Vector2 posicaoEntrada)
    {
        Vector2 posicaoPlayer = gameObject.transform.position;
        Vector2 posicaoMouse = cameraLocal.ScreenToWorldPoint(posicaoEntrada);
        float interseccaoY = posicaoPlayer.y - (slopeNegativo * posicaoPlayer.x);
        float entradaInterseccao = posicaoMouse.y - (slopeNegativo * posicaoMouse.x);
        return entradaInterseccao > interseccaoY;
    }

    /* Método que retorna o quadrante com base nas informações do slope */
    Quadrante PegaQuadrante()
    {
        Vector2 posicaoMouse = Input.mousePosition;
        Vector2 posicaoPLayer = transform.position;
        bool acimaSlopePositivo = AcimaSlopePositivo(Input.mousePosition);
        bool acimaSlopeNegativo = AcimaSlopeNegativo(Input.mousePosition);
        if(!acimaSlopePositivo && acimaSlopeNegativo)
        {
            return Quadrante.Leste;
        }
        if(!acimaSlopePositivo && !acimaSlopeNegativo)
        {
            return Quadrante.Sul;
        }
        if(acimaSlopePositivo && !acimaSlopeNegativo)
        {
            return Quadrante.Oeste;
        }
        else
        {
            return Quadrante.Norte;
        }
    }

    /* Método que atualiza o estado das animações de ataque e sua respectiva posição de acordo com o lado que estiver atirando */
    void UpdateEstado()
    {
        if (atirando)
        {
            Vector2 vetorQuadrante;
            Quadrante quadranteEnum = PegaQuadrante();
            switch (quadranteEnum)
            {
                case Quadrante.Leste:
                    vetorQuadrante = new Vector2(1.0f, 0.0f);
                    break;
                case Quadrante.Sul:
                    vetorQuadrante = new Vector2(0.0f, -1.0f);
                    break;
                case Quadrante.Oeste:
                    vetorQuadrante = new Vector2(-1.0f, 1.0f);
                    break;
                case Quadrante.Norte:
                    vetorQuadrante = new Vector2(0.0f, 0.0f);
                    break;
                default:
                    vetorQuadrante = new Vector2(0.0f, 0.0f);
                    break;
            }
            animator.SetBool("Atirando", true);
            animator.SetFloat("AtiraX", vetorQuadrante.x);
            animator.SetFloat("AtiraY", vetorQuadrante.y);

            atirando = false;
        }
        else
        {
            animator.SetBool("Atirando", false);
        }
    }

    /* Update is called once per frame */
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            atirando = true;
            DisparaMunicao();
        }
        UpdateEstado();
    }

    /* Método que pega o valor do slope */
    float PegaSlope(Vector2 ponto1, Vector2 ponto2)
    {
        return (ponto2.y - ponto1.y) / (ponto2.x - ponto1.x);
    }

    /* Método responsável por spawnar a munição, ou seja, pega do pool e seta o objeto como ativo na posição informada */
    public GameObject SpawnMunicao(Vector3 posicao)
    {
        foreach(GameObject municao in municaoPiscina)
        {
            if(municao.activeSelf == false)
            {
                municao.SetActive(true);
                municao.transform.position = posicao;
                return municao;
            }
        }
        return null;
    }

    /* Método responsável por disparar a munição, iniciando a coroutine da trajetória do arco até o clique do mouse */
    void DisparaMunicao()
    {
        Vector3 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject municao = SpawnMunicao(transform.position);
        if(municao != null)
        {
            Arco arcoScript = municao.GetComponent<Arco>();
            float duracaoTrajetoria = 1.0f / velocidadeArma;
            StartCoroutine(arcoScript.arcoTrajetoria(posicaoMouse, duracaoTrajetoria));
        }

    }

    /* Ao destruir o objeto a pool também é destruida */
    private void OnDestroy()
    {
        municaoPiscina = null;
    }
}
