using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaranguejoMove : MonoBehaviour
{
     public float speed = 1.0f;
    public float changeTime= 1.0f;
    public float direction = 1; 
    private Rigidbody2D rig;
    float timer= 0.0f;

   

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        //temporizador para ele mudar a direcaoo
        timer-= Time.deltaTime;
        if(timer<=0)
        { 
            timer = changeTime;
            direction*=-1;
            
        }

        
    }

    void FixedUpdate()
    {
        //movimenta ele
       Vector2 position = rig.position;
       position.x= position.x + speed * Time.deltaTime * direction;
       rig.MovePosition(position);

    }
}
