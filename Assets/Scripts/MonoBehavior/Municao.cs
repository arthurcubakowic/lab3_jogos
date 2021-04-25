/// <summary>
/// Projeto Final Programaao Baseada em Componentes para Jogos
/// Prof Dr. Mario Minami
/// Feito Por: Arthur Cubakowic, RA: 11201722317
/// Data: 25/04/2021
/// Versao do Unity: 2020.3.0f1
/// </summary>

using UnityEngine;

public class Municao : MonoBehaviour
{
    public int danoCausado;         //poder de dano da munição

    // Ao tocar no inimigo aplica dano
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is BoxCollider2D)
        {
            if (collision.gameObject.tag == "Inimigo") 
            {
                Inimigo inimigo = collision.gameObject.GetComponent<Inimigo>();
                StartCoroutine(inimigo.DanoCaractere(danoCausado, 0.0f));
                gameObject.SetActive(false);
            }
        }
    }

}
