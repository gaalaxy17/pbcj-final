using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>
/// Classe que gerencia o inventário do jogo
/// </summary>
public class Inventario : MonoBehaviour
{
    public GameObject slotPrefab; // prefab do slot
    public const int numSlots = 5; // número maximo de slots
    Image[] itemImages = new Image[numSlots]; // lista de imagem do itens
    public Item[] items = new Item[numSlots]; // lista de itens
    GameObject[] slots = new GameObject[numSlots]; // lista de slots

    /* Start is called before the first frame update */
    void Start()
    {
        CriaSlots();
    }

    /* Update is called once per frame */
    void Update()
    {
        int itemsCount = 0;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                itemsCount++;
            }
        }

        if (itemsCount >= 5)
        {
            PlayerPrefs.DeleteKey("health");
            SceneManager.LoadScene("Lab5_win");
        }
    }

    /* Método responsável por criar os slots do inventário */
    public void CriaSlots()
    {
        if(slotPrefab != null)
        {
            for(int i = 0; i < numSlots; i++)
            {
                GameObject novoSlot = Instantiate(slotPrefab);
                novoSlot.name = "ItemSlot_" + i;
                novoSlot.transform.SetParent(gameObject.transform.GetChild(0).transform);
                slots[i] = novoSlot;
                itemImages[i] = novoSlot.transform.GetChild(1).GetComponent<Image>();
            }
        }
    }

    /* Método responsável por adicionar o item no inventário */
    public bool AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if(items[i] != null && items[i].tipoItem == itemToAdd.tipoItem && itemToAdd.empilhavel == true)
            {
                items[i].quantidade = items[i].quantidade + 1;
                Slot slotScript = slots[i].gameObject.GetComponent<Slot>();
                Text quantidadeTexto = slotScript.qtdTexto;
                quantidadeTexto.enabled = true;
                quantidadeTexto.text = items[i].quantidade.ToString();
                return true;
            }
            if(items[i] == null)
            {
                items[i] = Instantiate(itemToAdd);
                items[i].quantidade = 1;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return true;
            }

        }
        return false;
    }
}
