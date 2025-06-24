using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithPlayer : MonoBehaviour
{
  public Transform particleSystemTransform; // Referência ao Transform do sistema de partículas

    void Update()
    {
        if (particleSystemTransform != null)
        {
            // Obtém a rotação do jogador (no eixo Z, que é relevante para 2D)
            float playerRotationZ = transform.eulerAngles.z;

            // Aplica a rotação ao sistema de partículas, mantendo a orientação horizontal
            particleSystemTransform.rotation = Quaternion.Euler(0f, 0f, playerRotationZ);
        }
    }
}