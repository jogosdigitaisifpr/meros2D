using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuidado : MonoBehaviour
{
    public GameObject texto;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            texto.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            texto.SetActive(false);
        }
    }
}
