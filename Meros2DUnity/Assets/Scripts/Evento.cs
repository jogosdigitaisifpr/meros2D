using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Evento : MonoBehaviour
{
    public Transform pauseMenu;
    private bool somOn = true;
    private bool pauseOn = false;
    [SerializeField] Image soundOff;
    [SerializeField] Image pOff;
    [SerializeField] Image soundOn;
    [SerializeField] Image pOn;
    public float passouFase = 0;
    public GameObject bt0;
    public Button bt1;
    public GameObject bt2;

    private void Start()
    {
        if (soundOn != null)
            soundOn.enabled = false;
        if (pOn != null)
            pOn.enabled = false;
        if (soundOff != null)
            soundOff.enabled = true;
        if (pOff != null)
            pOff.enabled = true;
        Time.timeScale = 1;
        Time.timeScale = 1;
        pauseOn = false;

        // Restaura o valor salvo (1 = som ligado, 0 = som desligado)
        somOn = PlayerPrefs.GetInt("SomLigado", 1) == 1;

        // Aplica o volume corretamente com base na configura��o salva
        AudioListener.volume = somOn ? 1 : 0;

        // Atualiza os �cones
        OnOff();
        Time.timeScale = 1;
        pauseOn = false;

        OnOffPause();


    }
    void Update()
    {
        OnOff();
        OnOffPause();
    }
    public void BotaoJogabilidade()
    {
        SceneManager.LoadScene("Jogabilidade");
    }
    public void BotaoCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    //botao que puxa a primeira fase
    public void BotaoJogar()
    {
        SceneManager.LoadScene("Fase1_1");
    }
    //botao que puxa a cena para selecionar a fase
    public void BotaoFases()
    {
        SceneManager.LoadScene("DesbloqueandoFase");
    }
    //botao que puxa a cena que explica a narrativa do jogo
    public void BotaoNarrativa()
    {
        SceneManager.LoadScene("Narrativa");
    }
    //sair do jogo
    public void BotaoSair()
    {
        SceneManager.LoadScene("DesbloqueandoFase");
    }
    public void BotaoInfo()
    {
        SceneManager.LoadScene("Maisinfo");
    }
    //botao que volta para a cena de menu
    public void BotaoVoltar()
    {
        SceneManager.LoadScene("Menu");
       // pauseMenu.gameObject.SetActive(false);

    }
    //botao que seleciona se o jogo vai estar com volume ou nao
    public void BotaoSom()
    {
        somOn = !somOn;

        AudioListener.volume = somOn ? 1 : 0;

        // Salva o novo estado
        PlayerPrefs.SetInt("SomLigado", somOn ? 1 : 0);
        PlayerPrefs.Save();

        // Atualiza os �cones
        OnOff();
    }
    public void BotaoPause()
    {
        pauseOn = !pauseOn;

        if (pauseOn)
        {
            Time.timeScale = 0;
            if (pauseMenu != null)
                pauseMenu.gameObject.SetActive(true); // Mostra o menu se quiser
        }
        else
        {
            Time.timeScale = 1;
            if (pauseMenu != null)
                pauseMenu.gameObject.SetActive(false);
        }

        OnOffPause();
    }

    public void BtResume()
    {
        pauseOn = false;
        Time.timeScale = 1;
        if (pauseMenu != null)
            pauseMenu.gameObject.SetActive(false);

        OnOffPause();
    }

    public void OnOffPause()
    {
        if (pOn != null)
            pOn.enabled = !pauseOn;  // �cone de "pausar" aparece quando n�o est� pausado
        if (pOff != null)
            pOff.enabled = pauseOn;  // �cone de "continuar" aparece quando est� pausado
    }

    //desativa a imagem de que esta com som para ativar que esta sem som
    public void OnOff()
    {
        if (soundOn != null)
            soundOn.enabled = somOn;
        if (soundOff != null)
            soundOff.enabled = !somOn;
    }
    //volta do pause
    
    //botao para carregar a primeira fase
    public void BtFaseMangue()
    {
        SceneManager.LoadScene("fase1_1");
    }
    //botao para carregar a segunda fase
    public void BtFaseEstuario()
    {
        SceneManager.LoadScene("fase1_2");
        
    }
    //botao para carregar a terceira fase
    public void BtFaseMar()
    {
        SceneManager.LoadScene("fase1_3");
    }
    //desbloqueia as fases de acordo com o avanco nas fases do jogador
    public void AtivarBotao(int ativarBotao)
    {
        passouFase = ativarBotao;
        if(passouFase == 0)
        {
            if (bt0 != null)
                bt0.GetComponent<Button>().enabled = true;
        }
        if(passouFase == 1)
        {
            if (bt1 != null)
                bt1.gameObject.SetActive (true);
        }
        if(passouFase == 2)
        {
            if (bt2 != null)
                bt2.GetComponent<Button>().enabled = true;
        }
    }
    
}
