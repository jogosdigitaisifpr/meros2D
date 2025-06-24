using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    private bool hasTriggered = false;
    private string cenaAnterior;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            StartCoroutine(TrocarParaCenaVideo());
        }
    }

    IEnumerator TrocarParaCenaVideo()
    {
        // Salva a cena atual
        cenaAnterior = SceneManager.GetActiveScene().name;

        // Pausa o jogo
        Time.timeScale = 0;

        // Carrega a cena do vídeo em modo aditivo
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("CenaDoVideo", LoadSceneMode.Additive);

        // Espera a cena do vídeo carregar completamente
        while (!asyncLoad.isDone)
            yield return null;

        // Espera 8 segundos em tempo real (ignora timeScale pausado)
        yield return new WaitForSecondsRealtime(8f);

        // Volta para a cena original
        SceneManager.UnloadSceneAsync("CenaDoVideo");

        // Retoma o tempo
        Time.timeScale = 1;

        // (opcional) Foca novamente na cena anterior se necessário
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(cenaAnterior));
    }
}