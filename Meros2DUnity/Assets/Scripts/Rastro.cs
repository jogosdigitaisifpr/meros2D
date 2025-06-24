using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rastro : MonoBehaviour
{
    GameObject obj;
    Player pla;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Player");
        pla = obj.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            pla.PerdeVida(-3);
        }
      
    }
}
