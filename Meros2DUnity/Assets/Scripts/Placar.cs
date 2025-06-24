using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Placar : MonoBehaviour
{
    
    
    GameObject obj;
    Player plc;
    public Text txtVida;
    void Start()
    {
        obj = GameObject.Find("Player");
        plc = obj.GetComponent<Player>();
        txtVida.text = plc.vida.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Vida();
    }
    
    public void Vida()
    {
        txtVida.text = plc.vida.ToString();
    }
}
