using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public GameObject somVida;
    public GameObject pl;
    GameObject obj;
    Player plc;
    void Start()
    {
        obj = GameObject.Find("Player");
        plc = obj.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Instantiate(somVida, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
            
            plc.GanhaVida(1);
            Destroy(this.gameObject);
        }
    }
}
