using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public List<GameObject> Cutscenes = new List<GameObject>();
    public Camera main;
    GameObject obj;
    Player pla;
    private void Awake()
    {
         obj = GameObject.Find("Player");
        pla = obj.GetComponent<Player>();
    }
    private void Start()
    {

        //começa a cutscene
        StartCutscene(0);
       
    }

    public void StartCutscene(int id)
    {
        pla.enabled = false;
        //ativa o objeto que começara a cutscene
        main.gameObject.SetActive(false);
        Cutscenes[id].SetActive(true);
        
    }
    public void StopCutscene(int id)
    {
        pla.enabled = true;
        //desativa o objeto que faz a cutscene
        main.gameObject.SetActive(true);
        Cutscenes[id].SetActive(false);
        
    }
}
