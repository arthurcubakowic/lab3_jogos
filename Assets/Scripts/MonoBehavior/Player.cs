/// <summary>
/// Projeto Final Programaao Baseada em Componentes para Jogos
/// Prof Dr. Mario Minami
/// Feito Por: Arthur Cubakowic, RA: 11201722317
/// Data: 25/04/2021
/// Versao do Unity: 2020.3.0f1
/// </summary>


using System.Collections;
using UnityEngine;

public class Player : Caractere
{
    public Inventario inventarioPrefab;         // Referência prefab do Inventário
    Inventario inventario;                      // Instancia do inventario

    public HealthBar healthBarPrefab;           // Referência prefab da HealthBar
    HealthBar healthBar;                        // Vida do Player

    public PontosDano pontosDano;               //Tem o valor do objeto script

    public static bool playerMorto;

    private void Start()
    {
        playerMorto = false; // garante que o player comece vivo

        inventario = Instantiate(inventarioPrefab);
        pontosDano.valor = inicioPontosDano;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.caractere = this;
    }

    // override na classe Player do Unity
    public override IEnumerator DanoCaractere(int dano, float intervalo)
    {
        while (true)
        {
            StartCoroutine(FlickCaractere());
            pontosDano.valor -= dano;

            // mata o player se ele tiver com 0 de vida
            if (pontosDano.valor <= float.Epsilon)
            {
                playerMorto = true;
                KillCaractere();
                break;
            }
            if (intervalo > float.Epsilon)
            {
                yield return new WaitForSeconds(intervalo);
            }
            else
            {
                break;
            }
        }
    }

    // override na classe Player do Unity
    public override void ResetCaractere()
    {
        inventario = Instantiate(inventarioPrefab);
        healthBar = Instantiate(healthBarPrefab);
        healthBar.caractere = this;
        pontosDano.valor = inicioPontosDano;
    }

    // override na classe Player do Unity
    public override void KillCaractere()
    {
        base.KillCaractere();
        Destroy(healthBar.gameObject);
        Destroy(inventario.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se o Objeto da Colisão for um coletavel
        if (collision.gameObject.CompareTag("Coletavel"))
        {
            Item DanoObjeto = collision.gameObject.GetComponent<Consumable>().item; // Referencia o Objeto que colidiu
            
            // Se o Objeto existir
            if (DanoObjeto != null)
            {

                bool DeveDesaparecer = false;

                
                switch (DanoObjeto.tipoItem)
                {
                    // Checa o tipo do Item e adiciona ele ao inventario do jogador, depois que o objeto for adicionado DeveDesaparecer vira verdadeiro
                    case Item.TipoItem.MOEDAAMARELA:
                        DeveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;

                    case Item.TipoItem.MOEDAAZUL:
                        DeveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;

                    case Item.TipoItem.MOEDAROXA:
                        DeveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;

                    case Item.TipoItem.MOEDAVERMELHA:
                        DeveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;

                    case Item.TipoItem.MOEDAVERDE:
                        DeveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;

                    // Adiciona vida ao jogador e depois transforma DeveDesaparecer em verdadeiro
                    case Item.TipoItem.HEALTH:
                        DeveDesaparecer = AjustePontosDano(DanoObjeto.quantidade);
                        break;
                    default:
                        break;

                }

                // Se DeveDesaparecer for verdadeiro, entao desativa o item com que o player colidiu
                if (DeveDesaparecer)
                {
                    collision.gameObject.SetActive(false);
                }
                
            }
          
        }
    }

    // Atualiza a UI da vida do Player
    public bool AjustePontosDano(int quantidade)
    {
        if (pontosDano.valor < MaxPontosDano)
        {
            pontosDano.valor += quantidade;
            print("Ajustando Pontos Dano por: " + quantidade + ". Novo Valor = " + pontosDano.valor);
            return true;
        }
        else return false;
    }
}


