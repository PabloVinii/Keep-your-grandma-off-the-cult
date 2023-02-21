using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Transform rotationObject; // objeto que define a rotação
    public float speedRotation = 1.0f; // velocidade de rotação

    void Update()
    {
    Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    if (direction != Vector2.zero) // verifica se o jogador está se movendo
        {
            Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, direction);
            Quaternion currentRotation = rotationObject.rotation;
            rotationObject.rotation = Quaternion.Slerp(currentRotation, desiredRotation, Time.deltaTime * speedRotation);
        }
    }
}
