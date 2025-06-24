using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Victory : MonoBehaviour
{
    public string faseParaCarregar;
    //public GameObject canva;
    // Start is called before the first frame update
    public float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime;
       
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {

           // canva.GetComponent<Evento>().AtivarBotao(1);
            SceneManager.LoadScene(faseParaCarregar);
            
            
        }
        
    }
}
