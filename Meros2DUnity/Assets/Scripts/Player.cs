using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Movimento")]
    [Tooltip("Velocidade de movimento (unidades por segundo).")]
    public float moveSpeed = 0f;
    [Tooltip("Ignora micro variações de input.")]
    public float deadZone = 0.05f;

    [Header("Rotação")]
    [Tooltip("Graus por segundo para girar em direção ao movimento.")]
    public float rotationSpeed = 720f;
    [Tooltip("Se o sprite aponta para cima (top-down clássico), use 90. Se aponta para a direita, use 0.")]
    public float spriteForwardOffset = 90f;

    [Header("Status")]
    public int vida = 3;
    public Vector3 Renasce = new Vector3(1.1f, 1.1f, 0);
    public GameObject somPerdeVida;

    [Header("Outros")]
    public ParticleRotation particleRotation;
    public GameObject android;
    public Animator animator;

    private Rigidbody2D rb;
    private Vector2 input;       
    private Vector2 moveDir;     
    private Vector2 lastMoveDir;
    private float time;

    void Start()
    {
              rb = GetComponent<Rigidbody2D>();
        if (!animator) animator = GetComponentInChildren<Animator>();

        // Config padrão para top-down 2D

        // IMPORTANTE: não congele a rotação se você quer usar MoveRotation
        // (Se você marcar Freeze Rotation Z no inspector, o MoveRotation NÃO irá girar.
        // Deixe destravado e confie no script para girar.)
        // Inicializa os componentes primeiro

        // Configurações padrão para top-down 2D
        rb.gravityScale = 0f;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        // Ativa controles Android se necessário
        if (Application.platform == RuntimePlatform.Android && android != null)
            android.SetActive(true);

        vida = 3;
        
    }

    void Update()
    {
        time += Time.deltaTime;

       // 2) Normaliza para não correr mais rápido na diagonal
        if (input.sqrMagnitude > 1f) input.Normalize();

        // 3) Dead zone
        if (input.magnitude < deadZone) input = Vector2.zero;

        // 4) Atualiza direção atual e última direção válida
        if (input != Vector2.zero)
        {
            moveDir = input.normalized;
            lastMoveDir = moveDir;
        }
  // 5) Parâmetros do Animator (se existir)
        if (animator)
        {
            // Quando parado, mantenha a última direção (Idle direcionado)
            Vector2 forAnim = (input == Vector2.zero) ? lastMoveDir : moveDir;
            animator.SetFloat("MoveX", forAnim.x);
            animator.SetFloat("MoveY", forAnim.y);
            animator.SetFloat("Speed", input.magnitude);
        }
    }

    void FixedUpdate()
    {
      // 6) Movimento pela física
        rb.velocity = input * moveSpeed;

        // 7) Rotação suave para onde estamos indo (se parado, mantém rotação atual)
        if (moveDir != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
            targetAngle -= spriteForwardOffset; // ajusta eixo "frente" do sprite
            float newAngle = Mathf.MoveTowardsAngle(rb.rotation, targetAngle, rotationSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(newAngle);
        }
    }

    // Novo Input System
    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    // ===== Vida =====
    public void GanhaVida(int valor)
    {
        vida = Mathf.Min(vida + valor, 3);
    }

    public void PerdeVida(int valor)
    {
        if (somPerdeVida)
            Instantiate(somPerdeVida, transform.position, Quaternion.identity);

        vida += valor;
        if (vida <= 0)
            SceneManager.LoadScene("GameOver");

        transform.position = Renasce;
        Debug.Log($"Agora você tem {vida} de vida");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Check"))
            Renasce = collision.transform.position;
    }

    public void AtivaAndroid() => android?.SetActive(true);
    public void DesativaAndroid() => android?.SetActive(false);

    void OnValidate()
    {
        moveSpeed = Mathf.Max(0f, moveSpeed);
        rotationSpeed = Mathf.Max(0f, rotationSpeed);
        deadZone = Mathf.Clamp(deadZone, 0f, 0.5f);
    }
}
