/// <summary>
/// Projeto Final Programaao Baseada em Componentes para Jogos
/// Prof Dr. Mario Minami
/// Feito Por: Arthur Cubakowic, RA: 11201722317
/// Data: 25/04/2021
/// Versao do Unity: 2020.3.0f1
/// </summary>


using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Loadfase1() // troca Cena para Fase 1
    {
        SceneManager.LoadScene("Fase 1");
    }

    public void LoadCreditos() // troca Cena para Creditos
    {
        SceneManager.LoadScene("Creditos");
    }

    public void LoadMenu() // troca Cena para Menu
    {
        SceneManager.LoadScene("Menu");
    }
}
