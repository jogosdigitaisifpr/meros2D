using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    Pescador pescadorScript;
    public int contaCut = 0;
    public int contaCutPescMal = 0;

    void Start()
    {
        // Obtém o componente SpriteRenderer do jogador
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Armazena a cor original do jogador
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto colidido tem a tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy") && contaCutPescMal > 0)
        {

            // Inicia a cor vermelha e chama a função para restaurar a cor original após 1 segundo
            StartCoroutine(FlashRed());
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy1"))
        {
            StartCoroutine(FlashRed());
        }
    }

    public IEnumerator FlashRed()
    {
        if (spriteRenderer != null)
        {
            // Muda a cor do jogador para vermelho
            spriteRenderer.color = Color.red;

            // Aguarda 1 segundo
            yield return new WaitForSeconds(1f);

            // Restaura a cor original
            spriteRenderer.color = originalColor;
        }
    }
}