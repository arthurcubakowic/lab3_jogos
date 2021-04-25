/// <summary>
/// Projeto Final Programaao Baseada em Componentes para Jogos
/// Prof Dr. Mario Minami
/// Feito Por: Arthur Cubakowic, RA: 11201722317
/// Data: 25/04/2021
/// Versao do Unity: 2020.3.0f1
/// </summary>

using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject itemPrefab; // Item que será dropado

    // Quando o NPC entrar com contato com o Player ele vai soltar um Item Chave
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is BoxCollider2D)
        {
            if (collision.gameObject.tag == "Player")
            {
                GameObject item = Instantiate(itemPrefab);
                item.transform.position = gameObject.transform.position;
            }
        }
    }

}
