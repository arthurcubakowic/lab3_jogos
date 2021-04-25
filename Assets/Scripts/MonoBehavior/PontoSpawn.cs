/// <summary>
/// Projeto Final Programaao Baseada em Componentes para Jogos
/// Prof Dr. Mario Minami
/// Feito Por: Arthur Cubakowic, RA: 11201722317
/// Data: 25/04/2021
/// Versao do Unity: 2020.3.0f1
/// </summary>


using UnityEngine;

public class PontoSpawn : MonoBehaviour
{
    public GameObject prefabParaSpawn; // Referencia o Prefab do Inimigo

    public float intervaloRepeticao;   // Interfalo de tempo até instanciar outro inimigo
    
    public void Start()
    {
        if (intervaloRepeticao > 0)
        {
            InvokeRepeating(nameof(Spawn0), 0.0f, intervaloRepeticao);
        }
    }

    // Spawna o inimigo
    public GameObject Spawn0()
    {

        if (prefabParaSpawn != null)
        {
            return Instantiate(prefabParaSpawn, transform.position, Quaternion.identity); // Instancia um inimigo
        }

        return null;
    }
}
