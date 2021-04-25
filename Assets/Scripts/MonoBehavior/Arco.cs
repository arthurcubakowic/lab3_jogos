/// <summary>
/// Projeto Final Programaao Baseada em Componentes para Jogos
/// Prof Dr. Mario Minami
/// Feito Por: Arthur Cubakowic, RA: 11201722317
/// Data: 25/04/2021
/// Versao do Unity: 2020.3.0f1
/// </summary>

using System.Collections;
using UnityEngine;

public class Arco : MonoBehaviour
{
    // Rotina que faz a trajetoria da municao
    public IEnumerator ArcoTrajetoria(Vector3 destino, float duracao)
    {
        var posicaoInicial = transform.position;
        var percenturalCompleto = 0.0f;

        while (percenturalCompleto < 1.0f)
        {
            percenturalCompleto += Time.deltaTime / duracao;
            var alturaCorrente = Mathf.Sin(Mathf.PI * percenturalCompleto);
            transform.position = Vector3.Lerp(posicaoInicial, destino, percenturalCompleto) + Vector3.up*alturaCorrente;
            percenturalCompleto += Time.deltaTime / duracao;
            yield return null;
        }
        gameObject.SetActive(false);
    }
    
}
