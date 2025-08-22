using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
 
public class Player : MonoBehaviour
{
    public float speed;    
    Rigidbody2D rb;
    private SpriteRenderer pl;
    private Animator pla;
    public int vida;
    public Vector3 Renasce = new Vector3(1.1f, 1.1f, 0);
    private Vector2 moveDirection;
    public float horizontal;
    public float vertical;
    public GameObject somPerdeVida;
    public float time;
    private Vector2 moveInput;
    private Vector3 lastMoveDirection;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int MoveDirectionX = Animator.StringToHash("MoveDirectionX");
    private static readonly int MoveDirectionY = Animator.StringToHash("MoveDirectionY");


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pl = GetComponent<SpriteRenderer>();
        pla = GetComponent<Animator>();
        vida = 3;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        UpdateAnimation();


    }
    
    private void FixedUpdate()
    {
        if(time>3.3f)
        {
            Walk();
        }
    }


    private void Walk()
    {
        if (moveInput.magnitude > 0.1f)
        {
            lastMoveDirection = moveInput.normalized;
        }

        Vector2 move = moveInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    private void UpdateAnimation()
    {
        pla.SetBool(IsWalking, moveInput != Vector2.zero);
        if (moveInput != Vector2.zero)
        {
            pla.SetFloat(MoveDirectionX, moveInput.x);
            pla.SetFloat(MoveDirectionY, moveInput.y);
        }
    }
    public void GanhaVida(int valor)
    {
        vida = vida + valor;
        if (vida > 3)
        {
            vida = 3;
        }
    }
    public void PerdeVida(int valor)
    {
        Instantiate(somPerdeVida, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
        
        vida = vida + valor;
        if (vida <= 0)
        {
           
           SceneManager.LoadScene("GameOver");
        }
        transform.position = Renasce;
        Debug.Log("agora voce tem" + " " + vida + " " + "de vida");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Check"))
        {
            Renasce = collision.transform.position;
        }
    }
    
     
    

}
