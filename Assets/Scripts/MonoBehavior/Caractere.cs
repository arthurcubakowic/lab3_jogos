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

public abstract class Caractere : MonoBehaviour
{
    
    public float inicioPontosDano; //Valor mínimo inicial de "vida" do Player
    public float MaxPontosDano;    //Valor máximo permitido de "vida" do Player

    public abstract void ResetCaractere();

    public virtual IEnumerator FlickCaractere()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    

    public abstract IEnumerator DanoCaractere(int dano, float intervalo);

    public virtual void KillCaractere()
    {
        Destroy(gameObject);
    }
}
