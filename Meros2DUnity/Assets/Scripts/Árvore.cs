using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Árvore : MonoBehaviour
{
   GameObject obj;
    Player pla;
    public Animator animArvore;
    
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Player");
        pla = obj.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        animArvore = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
          
            pla.moveSpeed = 4;
        }
        if(col.CompareTag("aguaEsgoto"))
        {
            animArvore.SetBool("Apodrecer", true);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            
            pla.moveSpeed = 10;
        }
    }
    
}
