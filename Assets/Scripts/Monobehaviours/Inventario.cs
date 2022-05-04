using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public GameObject slotPrefab;
    public const int numSlots = 5;
    Image[] itemImages = new Image[numSlots];
    Item[] items = new Item[numSlots];
    GameObject[] slots = new GameObject[numSlots];
    // Start is called before the first frame update
    void Start()
    {
        CriaSlots();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public bool AddItem(Item itemToAdd)
    {
        for(int i = 0; i < items.Length; i++)
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
