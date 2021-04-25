/// <summary>
/// Projeto Final Programaao Baseada em Componentes para Jogos
/// Prof Dr. Mario Minami
/// Feito Por: Arthur Cubakowic, RA: 11201722317
/// Data: 25/04/2021
/// Versao do Unity: 2020.3.0f1
/// </summary>


using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RPGGameManager : MonoBehaviour
{
    public static RPGGameManager instanciaCompartilhada = null;   // Instancia do Singleton

    // Variaveis de Referencia 
    public RPGCameraManager cameraManager;
    public PontoSpawn playerPontoSpawn;
    public GameObject DerrotaUI;
    public GameObject VitoriaUI;


    public bool comecou; // impede um erro em que o jogador perdia ou ganhava antes do jogo comecar
    public bool mostrandoVitoria;
    public bool mostrandoDerrota;

    private void Awake()
    {
        if (instanciaCompartilhada != null && instanciaCompartilhada != this) // Garante que seja Singleton
        {
            Destroy(gameObject);
        }
        else
        {
            instanciaCompartilhada = this;
        }
    }

    void Start()
    {
        comecou = false;
        SetupScene();               // Inicia Cena
        StartCoroutine(nameof(Comecou));
    }

    void Update()
    {
        // Completou o objetivo e ainda nao chamou vitoria, entao chama vitoria
        if (Inventario.objetivoCompleto && !mostrandoVitoria && comecou) 
        {
            Vitoria();
        }

        if (Player.playerMorto && !mostrandoDerrota && comecou)
        {
            Derrota();
        }
    }

    public IEnumerator Comecou()
    {

        yield return new WaitForSeconds(0.5f);
        comecou = true;

    }

    public void SetupScene()
    {
        SpawnPlayer(); // Spawna o Player


        VitoriaUI.SetActive(false); // Garente que vitoria nao seja mostrada no inicio
        mostrandoVitoria = false;

        DerrotaUI.SetActive(false); // Garente que derrota nao seja mostrada no inicio
        mostrandoDerrota = false;
    }

    public void SpawnPlayer()
    {
        if (playerPontoSpawn != null) // Se o PLayer nao tiver sido spawnado spawna ele
        {
            GameObject player = playerPontoSpawn.Spawn0();
            cameraManager.virtualCamera.Follow = player.transform;
        }
    }

    public void Vitoria()
    {
        mostrandoVitoria = true;                       // Impede que a funcao seja chamada infinitas vezes e a musica nao toque

        gameObject.GetComponent<AudioSource>().Stop(); // Pausa musica ambiente da tela
        VitoriaUI.SetActive(true);                     // Ativa a UI de vitoria
        VitoriaUI.GetComponent<AudioSource>().Play();  // Comeca musica de vitoria
    }

    public void Derrota()
    {
        mostrandoDerrota = true;                       // Impede que a funcao seja chamada infinitas vezes e a musica nao toque

        gameObject.GetComponent<AudioSource>().Stop(); // Pausa musica ambiente da tela
        DerrotaUI.SetActive(true);                     // Ativa a UI de Derrota
        DerrotaUI.GetComponent<AudioSource>().Play();  // Comeca musica de Derrota
    }

    public void LoadMenu() // troca para cena Menu
    {
        VitoriaUI.SetActive(false); // Garente que vitoria nao seja mostrada no inicio
        mostrandoVitoria = false;

        DerrotaUI.SetActive(false); // Garente que derrota nao seja mostrada no inicio
        mostrandoDerrota = false;

        SceneManager.LoadScene("Menu");
    }

    public void LoadFase1() // troca Cena para Fase 1
    {
        VitoriaUI.SetActive(false); // Garente que vitoria nao seja mostrada no inicio
        mostrandoVitoria = false;

        DerrotaUI.SetActive(false); // Garente que derrota nao seja mostrada no inicio
        mostrandoDerrota = false;

        SceneManager.LoadScene("Fase 1");
    }

    public void LoadFase2() // troca Cena para Fase 2
    {
        VitoriaUI.SetActive(false); // Garente que vitoria nao seja mostrada no inicio
        mostrandoVitoria = false;

        DerrotaUI.SetActive(false); // Garente que derrota nao seja mostrada no inicio
        mostrandoDerrota = false;

        SceneManager.LoadScene("Fase 2");
    }

    public void LoadFase3() // troca Cena para Fase 3
    {
        VitoriaUI.SetActive(false); // Garente que vitoria nao seja mostrada no inicio
        mostrandoVitoria = false;

        DerrotaUI.SetActive(false); // Garente que derrota nao seja mostrada no inicio
        mostrandoDerrota = false;

        SceneManager.LoadScene("Fase 3");
    }

    public void Restart() // Da load na mesma cena
    {
        VitoriaUI.SetActive(false); // Garente que vitoria nao seja mostrada no inicio
        mostrandoVitoria = false;

        DerrotaUI.SetActive(false); // Garente que derrota nao seja mostrada no inicio
        mostrandoDerrota = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
