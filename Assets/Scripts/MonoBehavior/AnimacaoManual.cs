/// <summary>
/// Projeto Final Programaao Baseada em Componentes para Jogos
/// Prof Dr. Mario Minami
/// Feito Por: Arthur Cubakowic, RA: 11201722317
/// Data: 25/04/2021
/// Versao do Unity: 2020.3.0f1
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimacaoManual : MonoBehaviour
{
    // Sistema de animacao para imagens
    public List<Sprite> spritesDaAnimacao;
    public int i;
    void Start()
    {
        i = 0;
        StartCoroutine(nameof(Animacao));
    }

    public IEnumerator Animacao() // a cada 0,1 segundos troca para proxima Sprite
    {
        i++;
        if (i >= spritesDaAnimacao.Count)
            i = 0;

        gameObject.GetComponent<Image>().sprite = spritesDaAnimacao[i];
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(nameof(Animacao));
    }
}
