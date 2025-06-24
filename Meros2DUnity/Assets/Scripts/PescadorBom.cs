using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PescadorBom : MonoBehaviour
{
    public GameObject player, ponto;
    public float speed;
    private bool seguiu;
    GameObject obj;
    Player pla;
    PlayerCollision scriptColisor;
    private Animator anim;
    private bool hasTriggered = false;
    private bool parado;

    public GameObject cutsceneObject; // Substitui o quad
    public GameObject fundoCut;
    public GameObject camera;
    private AudioSource cameraAudio;
    

    void Start()
    {
        player = GameObject.Find("Player");
        scriptColisor = GetComponent<PlayerCollision>();
        speed = 10;
        seguiu = false;
        anim = GetComponent<Animator>();
        obj = GameObject.Find("Player");
        pla = obj.GetComponent<Player>();
        cameraAudio = camera.GetComponent<AudioSource>();
        
    }

    void Update()
    {
        anim.SetBool("parado", parado);

        if (transform.position == ponto.transform.position)
        {
            parado = true;
        }
        else
        {
            parado = false;
        }

        if (!seguiu)
        {
            transform.position = Vector2.MoveTowards(transform.position, ponto.transform.position, speed * Time.deltaTime);
        }
    }

    private void Seguir()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && seguiu)
        {
            Seguir();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            seguiu = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            seguiu = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !hasTriggered)
        {
            ;
            player.transform.position = pla.Renasce;
            if(SceneManager.GetActiveScene().name == "fase1_2" && collision.gameObject.GetComponent<PlayerCollision>().contaCut == 0)
            {
                collision.gameObject.GetComponent<PlayerCollision>().contaCut++;
                 hasTriggered = true;
            StartCoroutine(TocarCutsceneAnimada());
            }
            
        }
    }

  IEnumerator TocarCutsceneAnimada()
{
    // Não pausar o tempo
    cameraAudio.Pause();
    fundoCut.SetActive(true);
        player.SetActive(false);
    Animator cutsceneAnimator = cutsceneObject.GetComponent<Animator>();
    if (cutsceneAnimator != null)
    {
        cutsceneAnimator.Play("CutsceneCompleta");
        Debug.Log("Animação da cutscene ativada.");
    }
    else
    {
        Debug.LogError("Animator não encontrado no cutsceneObject.");
    }
    // Aguarda a duração da animação
    yield return new WaitForSeconds(20f); // ajuste conforme o tempo da animação
    player.SetActive(true);
    fundoCut.SetActive(false); // Oculta novamente
    cameraAudio.UnPause();
    hasTriggered = false;
}
}
