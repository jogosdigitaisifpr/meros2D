using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    public GameObject RigidBodyPlayer;
    private Vector3 offset = new Vector3(0, 0, -15);


    // Update is called once per frame
    void Update()
    {   //faz a camera seguir o player
            transform.position = RigidBodyPlayer.transform.position + offset;  
    }
}
