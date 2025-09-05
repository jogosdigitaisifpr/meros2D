using UnityEngine;
public class ParticleRotation : MonoBehaviour
{
    public Transform playerTransform; 
    private ParticleSystem ps;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        if (playerTransform == null)
        {
            Debug.LogError("Player Transform não atribuído no ParticleRotation.");
        }
    }
    public void UpdateRotation(Vector2 moveDirection)
    {
        if (moveDirection == Vector2.zero)
            return;
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        
        transform.localRotation = Quaternion.Euler(angle, 0f, 0f);
    }
}