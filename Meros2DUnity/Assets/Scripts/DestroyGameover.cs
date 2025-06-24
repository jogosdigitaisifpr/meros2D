using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyGameover : MonoBehaviour
{
    public GameObject somGameOver;
    public float timeLevel;
    void Start()
    {
        //puxa a animacao de game over
        Instantiate(somGameOver, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        //temporizador para acabar a cena e puxar a cena de menu
        timeLevel = timeLevel + Time.deltaTime;
        Debug.Log(timeLevel);
        if(timeLevel>2.5f && SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene("Menu");
        }
        if (timeLevel > 6.0f && SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene("Ops");
        }
    }
}
