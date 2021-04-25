/// <summary>
/// Projeto Final Programaao Baseada em Componentes para Jogos
/// Prof Dr. Mario Minami
/// Feito Por: Arthur Cubakowic, RA: 11201722317
/// Data: 25/04/2021
/// Versao do Unity: 2020.3.0f1
/// </summary>

using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public Inventario instancia;                           // Singleton

    public GameObject slotPrefab;                          // Referencia o Prefab da interface de Slots de Items

    public const int numSlots = 5;                         // Define a quantidade de itens do jogo

    GameObject[] slots = new GameObject[numSlots];         // Array que armazena todos os Slots
    Image[] itemImagens = new Image[numSlots];             // Array que armazena o itemImage do Slot
    Item[] itens = new Item[numSlots];                     // Array que armazena todos os items nos Slots

    public static bool objetivoCompleto;                   // Informa o GameManager que o objetivo do jogo foi concluido

    void Start()
    {
        if (instancia != null && instancia != this) // Garante que seja Singleton
        {
            Destroy(gameObject);
        }
        else
        {
            instancia = this;
        }


        objetivoCompleto = false; // Garante que o jogo nao acabe antes de comecar

        CriaSlots();              // Cria os numSlots Slots de item
    }

    private void Update()
    {
        // Se todos os slots de item estiverem preenchidos o objetivo sera concluido
        if (itens[numSlots - 1] != null)
        {
            objetivoCompleto = true;
        }
    }

    // Cria os numSlots Slots de item
    public void CriaSlots()
    {
        if (slotPrefab != null)
        {
            for (int i = 0; i<numSlots; i++)
            {
                GameObject novoSlot = Instantiate(slotPrefab);                              // Instancia Item
                novoSlot.name = "ItemSlot_" + i;                                            // Da nome ao Game Object
                novoSlot.transform.SetParent(gameObject.transform.GetChild(0).transform);   // Transforma o Slot em filho de inventario
                slots[i] = novoSlot;                                                        // Adiciona o novo slot no Array de Slots
                itemImagens[i] = novoSlot.transform.GetChild(1).GetComponent<Image>();      // Adiciona o itemImage ao Array de imagens
            }
        }
    }

    // Cria o Item e retorna se ele deve ser deletado
    public bool AddItem(Item itemToAdd)
    {
        for (int i =0; i<itens.Length; i++)
        {
            // Se item existe, tem o mesmo tipo do item que será adicionado e é emplilhavel, entao:
            if (itens[i] != null && itens[i].tipoItem == itemToAdd.tipoItem && itemToAdd.empilhavel)
            {
                itens[i].quantidade = itens[i].quantidade + 1;                  // Adiciona um ao contador do item

                // Atualiza a UI de quantidade de itens no Slot
                Text quantidadeTexto = slots[i].gameObject.GetComponent<Slot>().qtdeTexto;
                quantidadeTexto.enabled = true;
                quantidadeTexto.text = itens[i].quantidade.ToString();

                return true;
            }

            // se não, adiciona um novo item no proximo slot disponivel 
            else if (itens[i] == null)
            {
                itens[i] = Instantiate(itemToAdd);              // Instancia o Item
                itens[i].quantidade = 1;                        // Inicializa a variavel quantidade de items no inventario
                itemImagens[i].sprite = itemToAdd.sprite;       // Adiciona a Sprite do item no Array de sprites
                itemImagens[i].enabled = true;                  // Ativa a Imagem do item

                // Atualiza a UI de quantidade de itens no Slot
                Text quantidadeTexto = slots[i].gameObject.GetComponent<Slot>().qtdeTexto;
                quantidadeTexto.enabled = true;
                quantidadeTexto.text = itens[i].quantidade.ToString();

                return true;
            }
        }
        return false;
    }
}
