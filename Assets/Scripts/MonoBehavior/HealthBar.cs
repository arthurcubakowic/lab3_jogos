/// <summary>
/// Projeto Final Programaao Baseada em Componentes para Jogos
/// Prof Dr. Mario Minami
/// Feito Por: Arthur Cubakowic, RA: 11201722317
/// Data: 25/04/2021
/// Versao do Unity: 2020.3.0f1
/// </summary>


using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PontosDano pontosDano;       // Vida do Payer
    public Player caractere;            // Referencia Player
    public Image medidorImagem;         // Imagem da Barra de vida
    public Text pdTexto;                // UI de quantos pontos de vida tem o jogador
    float maxPontosDano;                // Vida maxima do Player
    

    void Start()
    {
        maxPontosDano = caractere.MaxPontosDano; // Vida maxima do player local recebe vida maxima do player do Objeto Player
    }

    void Update()
    {
        if (caractere != null) // se o PLayer existe Atualiza UI
        {
            medidorImagem.fillAmount = pontosDano.valor/maxPontosDano; // Cria barra
            pdTexto.text = "PD:" + (medidorImagem.fillAmount * 100);   // Atualiza texto
        }
    }
}
