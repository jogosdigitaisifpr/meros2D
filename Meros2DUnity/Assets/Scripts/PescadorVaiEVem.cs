using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PescadorVaiEVem : MonoBehaviour
{
    public GameObject ponto1, ponto2, pl;
    private Vector2 nextPos;
    public float speed = 5;
    public bool direita;

    
    GameObject obj;
    Player pla;

    void Start()
    {
        nextPos = ponto2.transform.position;

        obj = GameObject.Find("Player");
        pl.GetComponent<Player>();
        pla = obj.GetComponent<Player>();
        pl = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        movingPlataform();
    }
    private void movingPlataform()
    {
        if (transform.position == ponto1.transform.position)
        {
            nextPos = ponto2.transform.position;

        }
        if (transform.position == ponto2.transform.position)
        {
            nextPos = ponto1.transform.position;

        }

        transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pla.PerdeVida(-1);
        }
    }
}
