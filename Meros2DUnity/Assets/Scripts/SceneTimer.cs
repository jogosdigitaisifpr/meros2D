using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTimer : MonoBehaviour
{
    private void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        // Inicia a coroutine para aguardar 3 segundos
        StartCoroutine(WaitAndLoadMenu());
         if (currentScene == "GameOver")
        {
            StartCoroutine(WaitAndLoadMenu());
        }
        else if (currentScene == "Victory")
        {
            StartCoroutine(WaitAndLoadMenu1());
        }
        
    }

    private IEnumerator WaitAndLoadMenu()
    {
        // Espera 3 segundos
        yield return new WaitForSeconds(6f);

        // Carrega a cena "Menu"
        SceneManager.LoadScene("MaisInfo");
    }
    private IEnumerator WaitAndLoadMenu1()
    {
        // Espera 3 segundos
        yield return new WaitForSeconds(6f);

        // Carrega a cena "Menu"
        SceneManager.LoadScene("DesbloqueandoFase");
    }

}